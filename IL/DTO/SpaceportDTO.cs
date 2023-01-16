namespace IL.DTO
{
    public class SpaceportDTO
    {
        public long Id { get; }
        public string Name { get; }
        public AstronomicalObjectDTO AstronomicalObject { get; }
        public SpaceportDTO(long id, string name, AstronomicalObjectDTO pointOfInterest)
        {
            Id = id;
            Name = name;
            AstronomicalObject = pointOfInterest;
        }
    }
}
