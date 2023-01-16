namespace IL.DTO
{
    public class SpaceshipDTO
    {
        public long Id { get; }
        public string Name { get; }
        public int Seat { get; }
        public decimal Speed { get; }
        public long Role { get; }

        public SpaceshipDTO(long id, string name, int seat, decimal speed, long role)
        {
            Id = id;
            Name = name;
            Seat = seat;
            Speed = speed;
            Role = role;
        }
    }
}
