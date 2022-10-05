namespace IL.DTO
{
    public class GateDTO
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public SpaceportDTO Spaceport { get; set; }

        public GateDTO(ulong id, string name, SpaceportDTO spaceport)
        {
            Id = id;
            Name = name;
            Spaceport = spaceport;
        }
    }
}
