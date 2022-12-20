using BLL.Entity;

namespace Algorithm
{
    public class FlightScheduler
    {
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> AOs { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public long[] SpaceshipStalling { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long SpaceshipAday { get; set; }
        private AstronomicalObject DepartAO { get; set; }

        public FlightScheduler(Spaceship spaceship, List<AstronomicalObject> aOs, List<AstronomicalObject> route, long[] spaceshipStalling, DateTime startDate, DateTime endDate, long spaceshipAday)
        {
            Spaceship = spaceship;
            Route = route;
            SpaceshipStalling = spaceshipStalling;
            StartDate = startDate;
            EndDate = endDate;
            SpaceshipAday = spaceshipAday;
        }

        public FlightScheduler(Spaceship spaceship, List<AstronomicalObject> aOs, DateTime startDate)
        {
            Spaceship = spaceship;
            AOs = aOs;
            StartDate = startDate;
            Route = new();
            spaceship.Speed /= 1000;
/*            if (CheckValid(CalculateBestRoute(0), 0))
            {
                PlanUntilUnvalid();
            }
*/        }



        public List<AstronomicalObject> CalculateBestRoute(ulong departureTime)
        {
            List<AstronomicalObject> tempAOs = AOs.ToList();
            foreach (AstronomicalObject AO in tempAOs.ToArray())
            {
                if (AO.Name == "Earth")
                {
                    DepartAO = AO;
                }
                if (AO.Name == "Sun")
                {
                    tempAOs.Remove(AO);
                }
            }
            List<AstronomicalObject> bAO = new();
            while (tempAOs.Count is not 0)
            {
                AstronomicalObject nearestAO = FindNearestAO(tempAOs, departureTime);
                DepartAO = nearestAO;
                bAO.Add(nearestAO);
                tempAOs.Remove(DepartAO);
            }
            return bAO;
        }

        private AstronomicalObject FindNearestAO(List<AstronomicalObject> AOs, ulong departureTime)
        {
            decimal flightRadius = 0;
            AstronomicalObject bao;
            do
            {
                flightRadius += 0.1m;
                CalculateAOposition(AOs, flightRadius, departureTime);
                bao = AOisInRadius(AOs, flightRadius);
            } while (bao is null);
            return bao;
        }

        private AstronomicalObject AOisInRadius(List<AstronomicalObject> AOs, decimal flightRadius)
        {
            foreach (var AO in AOs)
            {
                if (IsAOinFlightRadius(AO, flightRadius))
                {
                    CalculateAOposition(AOs, flightRadius, 1);
                    return AO;
                }
            }
            return null;
        }

        private void CalculateAOposition(List<AstronomicalObject> AOs, decimal flightRadius, ulong departureTime)
        {
            decimal perimeter = 0, arcLengthFromOrigin = 0, arcLengthTraveled = 0, arcLengthTraveledFromOrigin = 0;

            decimal flightDurationToFlightRadius = CalculateFlightDuration(flightRadius) + departureTime;

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

            double distance = CalculateFlightDistance(originAO, destinationAO);

            return (decimal)distance <= flightRadius;
        }

        private static double CalculateFlightDistance(double[] originCoordinates, double[] destinationCoordinates)
        {
            if (originCoordinates == null || destinationCoordinates == null || originCoordinates.Length != 3 || destinationCoordinates.Length != 3)
            {
                throw new ArgumentException("Invalid input coordinates");
            }

            try
            {
                double dx = originCoordinates[0] - destinationCoordinates[0];
                double dy = originCoordinates[1] - destinationCoordinates[1];
                double dz = originCoordinates[2] - destinationCoordinates[2];
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating distance: " + ex.Message);
                return double.NaN;
            }
        }

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