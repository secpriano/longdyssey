using System.Runtime.InteropServices;

namespace BLL.Entity
{
    internal class FlightLineScheduler
    {
        public Spaceship Spaceship { get; set; }
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
            AOs = aOs;
            Route = route;
            SpaceshipStalling = spaceshipStalling;
            StartDate = startDate;
            EndDate = endDate;
            SpaceshipAday = spaceshipAday;
        }

        public FlightLineScheduler(Spaceship spaceship, List<AstronomicalObject> aOs, DateTime startDate)
        {
            Spaceship = spaceship;
            AOs = aOs;
            Route = new();
            StartDate = startDate;
            spaceship.Speed = 0.00001M;
            foreach (AstronomicalObject AO in AOs)
            {
                if (AO.Name == "Earth")
                {
                    DepartAO = AO;
                    break;
                }
            }
            foreach (AstronomicalObject AO in AOs)
            {
                if (AO.Name == "Sun")
                {
                    AOs.Remove(AO);
                    break;
                }
            }

            while (AOs.Count is not 0)
            {
                FindNearestAO();
                AOs.Remove(DepartAO);
            }
            CheckValid();
        }

        private void FindNearestAO() 
        {
            decimal flightRadius = 0;
            
            do
            {
                flightRadius += 0.1m;
                CalculateAOposition(flightRadius, 0);
            
            } while (!CheckIfAOisInRadius(flightRadius));
        } 

        private bool CheckIfAOisInRadius(decimal flightRadius)
        {
            foreach (AstronomicalObject AO in AOs)
            {
                if (IsAOinFlightRadius(AO, flightRadius))
                {
                    Route.Add(AO);
                    DepartAO = AO;
                    CalculateAOposition(flightRadius, 1);
                    return true;
                }
            }
            return false;
        }

        private void CalculateAOposition(decimal flightRadius, byte transferTime) 
        {
            decimal perimeter = 0, arcLengthFromOrigin = 0, arcLengthTraveled = 0, arcLengthTraveledFromOrigin = 0;

            decimal flightDurationToFlightRadius = CalculateFlightDuration(flightRadius) + transferTime;

            AOs.ForEach(AO =>
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

        private static void CheckValid() 
        {
        } 
        
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
