namespace IL.DTO
{
    public class PointOfInterestDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }

        public PointOfInterestDTO(long id, string name, decimal radius, decimal azimuth, decimal inclination)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
        }
    }
}
