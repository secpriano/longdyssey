using IL.DTO;

namespace BLL.Entity
{
    public class PointOfInterest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }

        public PointOfInterest(long id, string name, decimal radius, decimal azimuth, decimal inclination)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
        }

        public PointOfInterest(PointOfInterestDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Radius = dto.Radius;
            Azimuth = dto.Azimuth;
            Inclination = dto.Inclination;
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

        public PointOfInterestDTO GetDTO() => new(Id, Name, Radius, Azimuth, Inclination);

        public enum Coordinates
        {
            X,
            Y,
            Z
        }
    }
}
