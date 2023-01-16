namespace IL.DTO
{
    public class AstronomicalObjectDTO
    {
        public long Id { get; }
        public string Name { get; }
        public decimal Radius { get; }
        public decimal Azimuth { get; }
        public decimal Inclination { get; }
        public decimal OrbitalSpeed { get;}

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
