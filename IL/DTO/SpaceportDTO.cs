namespace IL.DTO
{
    public class SpaceportDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public PointOfInterestDTO PointOfInterest { get; set; }
        public SpaceportDTO(long id, string name, PointOfInterestDTO pointOfInterest)
        {
            Id = id;
            Name = name;
            PointOfInterest = pointOfInterest;
        }
    }
}
