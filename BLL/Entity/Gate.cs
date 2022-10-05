using IL.DTO;

namespace BLL.Entity
{
    public class Gate
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public Spaceport Spaceport { get; set; }

        public Gate(ulong id, string name, Spaceport spaceport)
        {
            Id = id;
            Name = name;
            Spaceport = spaceport;
        }

        public Gate(GateDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Spaceport = new(dto.Spaceport);
        }
    }
}
