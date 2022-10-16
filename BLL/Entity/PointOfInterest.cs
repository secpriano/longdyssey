namespace BLL.Entity
{
    public class PointOfInterest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal AngleX { get; set; }
        public decimal AngleY { get; set; }

        public PointOfInterest(long id, string name, decimal radius, decimal angleX, decimal angleY)
        {
            Id = id;
            Name = name;
            Radius = radius;
            AngleX = angleX;
            AngleY = angleY;
        }

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public double[] SphericalToCartesianCoordinates()
        {
            double azimuth = DegreeToRadians((double)AngleX);
            double inclination = DegreeToRadians((double)AngleY);

            return new double[3]
            {
                (double)Radius * Math.Cos(inclination) * Math.Cos(azimuth),
                (double)Radius * Math.Cos(inclination) * Math.Sin(azimuth),
                (double)Radius * Math.Sin(inclination)
            };
        }
    }
}
