using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using UIL;

namespace BLL.Entity
{
    public class FlightLineScheduler
    {
        private readonly Dienstregeling FormDienstregeling;
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> TempAOs { get; set; }
        public List<AstronomicalObject> AOs { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public long[] SpaceshipStalling { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long SpaceshipAday { get; set; }
        private AstronomicalObject DepartAO { get; set; }

        public FlightLineScheduler(Spaceship spaceship, List<AstronomicalObject> aOs, List<AstronomicalObject> route, long[] spaceshipStalling, DateTime startDate, DateTime endDate, long spaceshipAday)
        {
            Spaceship = spaceship;
            TempAOs = aOs;
            Route = route;
            SpaceshipStalling = spaceshipStalling;
            StartDate = startDate;
            EndDate = endDate;
            SpaceshipAday = spaceshipAday;
        }

        public FlightLineScheduler(Dienstregeling formDienstregeling, Spaceship spaceship, List<AstronomicalObject> aOs, DateTime startDate)
        {
            FormDienstregeling = formDienstregeling;
            Spaceship = spaceship;
            AOs = aOs;
            StartDate = startDate;
            Route = new();
            //TempAOs = new();
            spaceship.Speed /= 10000;

            if (CheckValid(CalculateBestRoute(0), 0))
            {
                PlanUntilUnvalid();
            }
        }

        private List<AstronomicalObject> CalculateBestRoute(ulong departureTime)
        {
            TempAOs = AOs.ToList();
            foreach (AstronomicalObject AO in TempAOs.ToArray())
            {
                if (AO.Name == "Earth")
                {
                    DepartAO = AO;
                }
                if (AO.Name == "Sun")
                {
                    TempAOs.Remove(AO);
                }
            }
            List<AstronomicalObject> bAO = new();
            while (TempAOs.Count is not 0)
            {
                AstronomicalObject nearestAO = FindNearestAO(departureTime);
                DepartAO = nearestAO;
                bAO.Add(nearestAO);
                TempAOs.Remove(DepartAO);
            }
            return bAO;
        }

        private AstronomicalObject FindNearestAO(ulong departureTime) 
        {
            decimal flightRadius = 0;
            FormDienstregeling.DrawFlightRadius(DepartAO, flightRadius);
            AstronomicalObject bao;
            do
            {
                flightRadius += 0.1m;
                CalculateAOposition(flightRadius, departureTime);
                FormDienstregeling.DrawFlightRadius(DepartAO, flightRadius);
                bao = AOisInRadius(flightRadius);
            } while (bao is null);
            return bao;
        }

        private AstronomicalObject AOisInRadius(decimal flightRadius)
        {
            foreach (var AO in TempAOs)
            {
                if (IsAOinFlightRadius(AO, flightRadius))
                {
                    CalculateAOposition(flightRadius, 1);
                    return AO;
                }
            }
            return null;
        }

        private void CalculateAOposition(decimal flightRadius, ulong departureTime) 
        {
            decimal perimeter = 0, arcLengthFromOrigin = 0, arcLengthTraveled = 0, arcLengthTraveledFromOrigin = 0;

            decimal flightDurationToFlightRadius = CalculateFlightDuration(flightRadius) + departureTime;

            TempAOs.ForEach(AO =>
            {
                perimeter = CalculatePerimeter(AO.Radius);
                arcLengthFromOrigin = CalculateAOarcLengthFromOrigin(AO.Azimuth, perimeter);
                arcLengthTraveled = CalculateArcLengthTraveled(AO.OrbitalSpeed, flightDurationToFlightRadius);
                arcLengthTraveledFromOrigin = arcLengthFromOrigin + arcLengthTraveled;
                AO.Azimuth = TranslateAUtoDegrees(perimeter, arcLengthTraveledFromOrigin);
            });
        }

        private static decimal CalculatePerimeter(decimal R) => (decimal)(Math.PI * 2 * (double)R);
        private static decimal CalculateAOarcLengthFromOrigin(decimal azimuth, decimal perimeter) => azimuth * (perimeter / 360);
        private static decimal KmsToKmh(decimal orbitalSpeed) => orbitalSpeed * 3600;
        private static decimal KmToAU(decimal distanceInKm) => distanceInKm / 149597870.7M;
        private static decimal CalculateArcLengthTraveled(decimal orbitalSpeed, decimal time) => KmToAU(KmsToKmh(orbitalSpeed) * time);
        private static decimal TranslateAUtoDegrees(decimal perimeter, decimal arcLength) => 360 / perimeter * arcLength % 360;

        private bool IsAOinFlightRadius(AstronomicalObject AO, decimal flightRadius)
        {
            double[] originAO = DepartAO.SphericalToCartesianCoordinates();
            double[] destinationAO = AO.SphericalToCartesianCoordinates();

            double distance = CalcuclateFlightDistance(originAO, destinationAO);

            return (decimal)distance <= flightRadius;
        }
        private static double CalcuclateFlightDistance(double[] originCoordinates, double[] destinationCoordinates) => Math.Sqrt(
            Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.X] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.X], 2)
            +
            Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.Y] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.Y], 2)
            +
            Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.Z] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.Z], 2)
        );

/*        private bool CheckValid(List<AstronomicalObject> bestRoute, ulong departureDate) 
        {
            for (ulong i = departureDate; i <= departureDate+31; i++)
            {
                List<AstronomicalObject> bestRouteOfTheDay = CalculateBestRoute(24);
                for (byte j = 0; j < bestRoute.Count; j++)
                {
                    if (bestRouteOfTheDay[j].Id != bestRoute[j].Id)
                    {
                        Route = bestRouteOfTheDay;
                        AOs = bestRouteOfTheDay;
                        i++;
                        CheckValid(bestRouteOfTheDay, i);
                    }
                    else
                    {
                        Route = bestRoute;
                    }
                }
            }
            return true;
        } 
*/        
        private void PlanUntilUnvalid() 
        {
        } 
        
        private void CalculateAmountSpaceshipNeededOnAO() 
        {
        } 

        public void AddSchedule(DateTime startDate, DateTime endDate, long spaceshipId, long spaceshipAday)
        {

        }

        private decimal CalculateFlightDuration(decimal distance)
        {
            const decimal AUinKM = 149597870.7M;
            const decimal CinKM = 299792.458M;

            decimal flightDurationInSeconds = distance * AUinKM / (Spaceship.Speed * CinKM);
            decimal flightDurationInHours = flightDurationInSeconds / 3600;

            return flightDurationInHours;
        }

    }
}
