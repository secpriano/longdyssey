namespace IL.DTO
{
    public class SpaceshipDTO
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public ushort Seat { get; set; }
        public byte Speed { get; set; }
        public string Role { get; set; }

        public SpaceshipDTO(ulong id, string name, ushort seat, byte speed, string role)
        {
            Id = id;
            Name = name;
            Seat = seat;
            Speed = speed;
            Role = role;
        }
    }
}
