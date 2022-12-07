namespace IL.DTO
{
    public class SpaceportDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AstronomicalObjectDTO AstronomicalObject { get; set; }
        public SpaceportDTO(long id, string name, AstronomicalObjectDTO pointOfInterest)
        {
            Id = id;
            Name = name;
            AstronomicalObject = pointOfInterest;
        }
    }
}
