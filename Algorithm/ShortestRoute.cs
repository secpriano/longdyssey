using BLL.Entity;
using IL.Interface.DAL;

namespace Algorithm
{
    public class ShortestRoute
    {
        private const decimal FlightRadiusIncrement = 0.1m;
        private const int SpeedConversionFactor = 1;
        private const int SecondsPerHour = 3600;
        private const decimal AstronomicalUnitInKilometers = 149597870.7M;
        private const decimal CInKilometers = 299792.458M;

        public Spaceship Spaceship { get; }
        public List<AstronomicalObject> AOs { get; }
        private AstronomicalObject DepartureAO { get; set; }

        public ShortestRoute(ISpaceshipDAL spaceshipDb, string selectedSpaceshipName, IAstronomicalObjectDAL astronomicalObjectDb, DateTime startDate)
        {
            
            Spaceship = new(spaceshipDb.GetAll().FirstOrDefault(spaceship => spaceship.Name == selectedSpaceshipName));
            AOs = astronomicalObjectDb.GetAll().Select(AO => new AstronomicalObject(AO)).ToList();
            Spaceship.Speed /= SpeedConversionFactor;

            DateTime AOstartPositionDate = new DateTime(1969, 7, 20);

            ulong hours = (ulong)(startDate - AOstartPositionDate).TotalHours;

            CalculateAOposition(AOs, hours);
        }

        public List<AstronomicalObject> CalculateBestRoute()
        {
            List<AstronomicalObject> tempAOs = AOs.ToList();
            foreach (AstronomicalObject AO in tempAOs.ToArray())
            {
                if (AO.Name == "Earth")
                {
                    DepartureAO = AO;
                }
                if (AO.Name == "Sun")
                {
                    tempAOs.Remove(AO);
                }
            }
            List<AstronomicalObject> bestAOs = new();
            while (tempAOs.Count != 0)
            {
                AstronomicalObject nearestAO = FindNearestAO(tempAOs);
                DepartureAO = nearestAO;
                bestAOs.Add(nearestAO);
                tempAOs.Remove(DepartureAO);
            }
            return bestAOs;
        }

        private AstronomicalObject FindNearestAO(List<AstronomicalObject> AOs)
        {
            decimal flightRadius = 0;
            AstronomicalObject bestAO;
            do
            {
                flightRadius += FlightRadiusIncrement;
                CalculateAOposition(AOs, flightRadius);
                bestAO = AOisInRadius(AOs, flightRadius);
            } while (bestAO is null);
            return bestAO;
        }

        private AstronomicalObject AOisInRadius(List<AstronomicalObject> AOs, decimal flightRadius)
        {
            foreach (var AO in AOs)
            {
                if (IsAOinFlightRadius(AO, flightRadius))
                {
                    CalculateAOposition(AOs, CalculateFlightDuration(flightRadius));
                    return AO;
                }
            }
            return null;
        }
        
        private void CalculateAOposition(List<AstronomicalObject> AOs, decimal durationHour)
        {
            AOs.ForEach(AO =>
            {
                decimal perimeter = CalculatePerimeter(AO.Radius);
                decimal arcLengthFromOrigin = CalculateArcLengthFromOrigin(AO.Azimuth, perimeter);
                decimal arcLengthTraveled = CalculateArcLengthTraveled(AO.OrbitalSpeed, durationHour);
                decimal arcLengthTraveledFromOrigin = arcLengthFromOrigin + arcLengthTraveled;
                AO.Azimuth = TranslateAUtoDegrees(perimeter, arcLengthTraveledFromOrigin);
            });
        }

        private static decimal CalculatePerimeter(decimal radius) => (decimal)Math.PI * 2 * radius;
        private static decimal CalculateArcLengthFromOrigin(decimal azimuth, decimal perimeter) => azimuth * (perimeter / 360);
        private static decimal CalculateArcLengthTraveled(decimal orbitalSpeed, decimal timeHour) => KmToAU(KmsToKmh(orbitalSpeed) + timeHour);
        private static decimal KmToAU(decimal distanceInKm) => distanceInKm / AstronomicalUnitInKilometers;
        private static decimal KmsToKmh(decimal speedInKms) => speedInKms * SecondsPerHour;
        private decimal CalculateFlightDuration(decimal flightRadius) => flightRadius * AstronomicalUnitInKilometers / (Spaceship.Speed * CInKilometers);

        private static decimal TranslateAUtoDegrees(decimal perimeter, decimal arcLengthTraveledFromOrigin)
        {
            if (perimeter != 0)
            {
                return arcLengthTraveledFromOrigin * 360 / perimeter;
            }

            return 0;
        }
        
        private bool IsAOinFlightRadius(AstronomicalObject destinationAO, decimal flightRadius)
        {
            if (DepartureAO is null)
            {
                return false;
            }

            DepartureAO.SphericalToCartesianCoordinates(out double[] originCoordinates);
            destinationAO.SphericalToCartesianCoordinates(out double[] destinationCoordinates);

            double distance = CalculateFlightDistance(originCoordinates, destinationCoordinates);

            return (decimal)distance <= flightRadius;
        }

        public static double CalculateFlightDistance(double[] originCoordinates, double[] destinationCoordinates)
        {
            if (originCoordinates == null || destinationCoordinates == null || originCoordinates.Length != 3 || destinationCoordinates.Length != 3)
            {
                throw new ArgumentException("Invalid input coordinates");
            }

            try
            {
                double xDistance = originCoordinates[0] - destinationCoordinates[0];
                double yDistance = originCoordinates[1] - destinationCoordinates[1];
                double zDistance = originCoordinates[2] - destinationCoordinates[2];
                double distance = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2) + Math.Pow(zDistance, 2));
                return distance;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating distance: " + ex.Message);
                return double.NaN;
            }
        }
    }
}