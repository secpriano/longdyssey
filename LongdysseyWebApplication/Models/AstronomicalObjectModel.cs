using BLL.Entity;
using IL.DTO;

namespace LongdysseyWebApplication.Models
{
    public class AstronomicalObjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }
        public decimal OrbitalSpeed { get; set; }

        public AstronomicalObjectModel(AstronomicalObject AO)
        {
            Id = AO.Id;
            Name = AO.Name;
            Radius = AO.Radius;
            Azimuth = AO.Azimuth;
            Inclination = AO.Inclination;
            OrbitalSpeed = AO.OrbitalSpeed;
        }

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public double[] SphericalToCartesianCoordinates()
        {
            double azimuthInRadians = DegreeToRadians((double)Azimuth);
            double inclinationInRadians = DegreeToRadians((double)Inclination);

            return new double[3]
            {
                (double)Radius * Math.Cos(inclinationInRadians) * Math.Cos(azimuthInRadians),
                (double)Radius * Math.Cos(inclinationInRadians) * Math.Sin(azimuthInRadians),
                (double)Radius * Math.Sin(inclinationInRadians)
            };
        }

        public AstronomicalObjectDTO GetDTO() => new(Id, Name, Radius, Azimuth, Inclination, OrbitalSpeed);

        public enum Coordinates
        {
            X,
            Y,
            Z
        }
    }
}
