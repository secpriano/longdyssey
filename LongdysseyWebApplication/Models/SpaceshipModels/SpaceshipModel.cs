using BLL.Entity;

namespace WebApplication.Models.SpaceshipModels
{
    public class SpaceshipModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Seat { get; set; }
        public decimal Speed { get; set; }
        public long Role { get; set; }

        public SpaceshipModel(long id, string name, int seat, decimal speed, long role)
        { 
            Id = id;
            Name = name;
            Seat = seat;
            Speed = speed;
            Role = role;
        }
    }
}
