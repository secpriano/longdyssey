using System.Globalization;

namespace WebApplication.Models.Dienstregeling
{
    public class AstronomicalObjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }
        public string OrbitalSpeed { get; set; }

        public string Diameter { get; set; }
        public string X { get; set; }
        public string Y { get; set; }

        public AstronomicalObjectModel(long id, string name, decimal radius, decimal azimuth, decimal inclination, decimal orbitalSpeed)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
            OrbitalSpeed = ConvertToDot(orbitalSpeed);

            Init();
        }

        public void Init()
        {
            int zoom = 15;

            double[] CartesianCoordinates = SphericalToCartesianCoordinates((double)Radius, (double)Azimuth, (double)Inclination);

            X = ConvertToDot((decimal)(CartesianCoordinates[0] * zoom));
            Y = ConvertToDot((decimal)(CartesianCoordinates[1] * zoom));

            decimal diameter = Radius * 2 * zoom;
            Diameter = ConvertToDot(diameter);
        }

        private static string ConvertToDot(decimal commaValue) => Convert.ToString(commaValue, CultureInfo.GetCultureInfo("en-US"));

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public double[] SphericalToCartesianCoordinates(double radius, double azimuth, double inclination)
        {
            double azimuthInRadians = DegreeToRadians(azimuth);
            double inclinationInRadians = DegreeToRadians(inclination);

            return new double[3]
            {
                radius * Math.Cos(inclinationInRadians) * Math.Cos(azimuthInRadians),
                radius * Math.Cos(inclinationInRadians) * Math.Sin(azimuthInRadians),
                radius * Math.Sin(inclinationInRadians)
            };
        }
    }
}
