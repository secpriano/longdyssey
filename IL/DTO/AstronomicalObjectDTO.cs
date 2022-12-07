namespace IL.DTO
{
    public class AstronomicalObjectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }
        public decimal OrbitalSpeed { get; set; }

        public AstronomicalObjectDTO(long id, string name, decimal radius, decimal azimuth, decimal inclination, decimal orbitalSpeed)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
            OrbitalSpeed = orbitalSpeed;
        }
    }
}
