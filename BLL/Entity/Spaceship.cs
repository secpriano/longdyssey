using IL.DTO;

namespace BLL.Entity
{
    public class Spaceship
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Seat { get; set; }
        public decimal Speed { get; set; }
        public long Role { get; set; }

        public Spaceship()
        {

        }

        public Spaceship(long id, string name, int seat, decimal speed, long role)
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

        public SpaceshipDTO GetDTO() => new SpaceshipDTO(Id, Name, Seat, Speed, Role);
    }
}
