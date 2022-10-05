using IL.DTO;

namespace BLL.Entity
{
    public class Spaceship
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ushort Seat { get; set; }
        public byte Speed { get; set; }
        public string Role { get; set; }

        public Spaceship(ulong id, string name, ushort seat, byte speed, string role)
        {
            Id = id;
            Name = name;
            Seat = seat;
            Speed = speed;
            Role = role;
        }

        public Spaceship(SpaceshipDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Seat = dto.Seat;
            Speed = dto.Speed;
            Role = dto.Role;
        }
    }
}
