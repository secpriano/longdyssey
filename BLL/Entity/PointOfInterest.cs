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
    }
}
