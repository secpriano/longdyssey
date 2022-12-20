using IL.DTO;

namespace BLL.Entity
{
    public class AstronomicalObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }
        public decimal OrbitalSpeed { get; set; }

        public AstronomicalObject(long id, string name, decimal radius, decimal azimuth, decimal inclination, decimal orbitalSpeed)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
            OrbitalSpeed = orbitalSpeed;
        }

        public AstronomicalObject(AstronomicalObjectDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Radius = dto.Radius;
            Azimuth = dto.Azimuth;
            Inclination = dto.Inclination;
            OrbitalSpeed = dto.OrbitalSpeed;
        }

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public double[] SphericalToCartesianCoordinates()
        {
            double azimuthInRadians = DegreeToRadians((double)Azimuth);
            double inclinationInRadians = DegreeToRadians((double)Inclination);
            double cosAzimuth = Math.Cos(azimuthInRadians);
            double sinAzimuth = Math.Sin(azimuthInRadians);
            double cosInclination = Math.Cos(inclinationInRadians);
            double sinInclination = Math.Sin(inclinationInRadians);

            return new double[3]
            {
                (double)Radius * cosInclination * cosAzimuth,
                (double)Radius * cosInclination * sinAzimuth,
                (double)Radius * sinInclination
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
