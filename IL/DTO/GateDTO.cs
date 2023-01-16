namespace IL.DTO
{
    public class GateDTO
    {
        public long Id { get; }
        public string Name { get; }
        public SpaceportDTO Spaceport { get; }

        public GateDTO(long id, string name, SpaceportDTO spaceport)
        {
            Id = id;
            Name = name;
            Spaceport = spaceport;
        }
    }
}
