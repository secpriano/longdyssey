using IL.DTO;

namespace Algorithm
{
    public class FlightScheduler
    {
        public SpaceshipDTO Spaceship { get; set; }
        //public List<AstronomicalObjectDTO> TempAOs { get; set; }
        public List<AstronomicalObjectDTO> AOs { get; set; }
        public List<AstronomicalObjectDTO> Route { get; set; }
        public long[] SpaceshipStalling { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long SpaceshipAday { get; set; }
        private AstronomicalObjectDTO DepartAO { get; set; }

        public FlightScheduler(SpaceshipDTO spaceship, List<AstronomicalObjectDTO> aOs, List<AstronomicalObjectDTO> route, long[] spaceshipStalling, DateTime startDate, DateTime endDate, long spaceshipAday)
        {
            Spaceship = spaceship;
            Route = route;
            SpaceshipStalling = spaceshipStalling;
            StartDate = startDate;
            EndDate = endDate;
            SpaceshipAday = spaceshipAday;
        }

        public FlightScheduler(SpaceshipDTO spaceship, List<AstronomicalObjectDTO> aOs, DateTime startDate)
        {
            Spaceship = spaceship;
            AOs = aOs;
            StartDate = startDate;
            Route = new();
            spaceship.Speed /= 1000;
            Route = CalculateBestRoute(0);
/*            if (CheckValid(CalculateBestRoute(0), 0))
            {
                PlanUntilUnvalid();
            }
*/        }

        private List<AstronomicalObjectDTO> CalculateBestRoute(ulong departureTime)
        {
            List<AstronomicalObjectDTO> tempAOs = AOs.ToList();
            foreach (AstronomicalObjectDTO AO in tempAOs.ToArray())
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
            List<AstronomicalObjectDTO> bAO = new();
            while (tempAOs.Count is not 0)
            {
                AstronomicalObjectDTO nearestAO = FindNearestAO(tempAOs, departureTime);
                DepartAO = nearestAO;
                bAO.Add(nearestAO);
                tempAOs.Remove(DepartAO);
            }
            return bAO;
        }

        private AstronomicalObjectDTO FindNearestAO(List<AstronomicalObjectDTO> AOs, ulong departureTime)
        {
            decimal flightRadius = 0;
            AstronomicalObjectDTO bao;
            do
            {
                flightRadius += 0.1m;
                CalculateAOposition(AOs, flightRadius, departureTime);
                bao = AOisInRadius(AOs, flightRadius);
            } while (bao is null);
            return bao;
        }

        private AstronomicalObjectDTO AOisInRadius(List<AstronomicalObjectDTO> AOs, decimal flightRadius)
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

        private void CalculateAOposition(List<AstronomicalObjectDTO> AOs, decimal flightRadius, ulong departureTime)
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

        private bool IsAOinFlightRadius(AstronomicalObjectDTO AO, decimal flightRadius)
        {
            double[] originAO = SphericalToCartesianCoordinates(DepartAO);
            double[] destinationAO = SphericalToCartesianCoordinates(AO);

            double distance = CalculateFlightDistance(originAO, destinationAO);

            return (decimal)distance <= flightRadius;
        }

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public static double[] SphericalToCartesianCoordinates(AstronomicalObjectDTO AO)
        {
            double azimuthInRadians = DegreeToRadians((double)AO.Azimuth);
            double inclinationInRadians = DegreeToRadians((double)AO.Inclination);
            double cosAzimuth = Math.Cos(azimuthInRadians);
            double sinAzimuth = Math.Sin(azimuthInRadians);
            double cosInclination = Math.Cos(inclinationInRadians);
            double sinInclination = Math.Sin(inclinationInRadians);
            return new double[3]
            {
                (double)AO.Radius * cosInclination * cosAzimuth,
                (double)AO.Radius * cosInclination * sinAzimuth,
                (double)AO.Radius * sinInclination
            };
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

        /*        private bool CheckValid(List<AstronomicalObjectDTO> bestRoute, ulong departureDate) 
                {
                    for (ulong i = departureDate; i <= departureDate+31; i++)
                    {
                        List<AstronomicalObjectDTO> bestRouteOfTheDay = CalculateBestRoute(24);
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