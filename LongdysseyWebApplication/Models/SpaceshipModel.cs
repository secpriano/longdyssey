using BLL.Entity;

namespace LongdysseyWebApplication.Models
{
    public class SpaceshipModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Seat { get; set; }
        public decimal Speed { get; set; }
        public long Role { get; set; }

        public SpaceshipModel(Spaceship spaceship)
        {
            Id = spaceship.Id;
            Name = spaceship.Name;
            Seat = spaceship.Seat;
            Speed = spaceship.Speed;
            Role = spaceship.Role;
        }
    }
}
