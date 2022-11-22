using BLL.Entity;
using IL.DTO;

namespace LongdysseyWebApplication.Models
{
    public class PointOfInterestModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }

        public PointOfInterestModel(PointOfInterest POI)
        {
            Id = POI.Id;
            Name = POI.Name;
            Radius = POI.Radius;
            Azimuth = POI.Azimuth;
            Inclination = POI.Inclination;
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
