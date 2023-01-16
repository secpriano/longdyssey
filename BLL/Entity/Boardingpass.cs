using IL.DTO;

namespace BLL.Entity
{
    public class Boardingpass
    {
        public long Id { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
        public long Seat { get; set; }

        public Boardingpass(long id, Flight flight, User user, long seat)
        {
            Id = id;
            Flight = flight;
            User = user;
            Seat = seat;
        }
        
        public Boardingpass(Flight flight, User user, long seat)
        {
            Flight = flight;
            User = user;
            Seat = seat;
        }

        public Boardingpass(BoardingpassDTO dto)
        {
            Flight = new(dto.Flight);
            User = new(dto.User);
            Seat = dto.Seat;
        }

        public Boardingpass()
        {
        }

        public BoardingpassDTO GetDTO() => new(Flight.GetDTO(), User.GetDTO(), Seat);
    }
}
