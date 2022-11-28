using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class BoardingpassSTUB : IBoardingpassDAL
    {
        static readonly FlightSTUB FlightData = new();
        static readonly UserSTUB UserData = new();

        public List<BoardingpassDTO> boardingpasses = new()
        {
            new(FlightData.flights[1-1], UserData.users[1-1], 5)
        };

        public long FlightId { get; private set; }
        public long UserId { get; private set; }
        public long Seat { get; private set; }

        public bool BookFlight(long seat, long flightId, long userId)
        {
            FlightId = flightId;
            UserId = userId;
            Seat = seat;

            boardingpasses.Add(new(FlightData.flights[(int)flightId - 1], UserData.users[(int)userId - 1], seat));
            return true;
        }

        public bool DeleteByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<BoardingpassDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BoardingpassDTO> GetBookingByFlightId(long id)
        {
            throw new NotImplementedException();
        }

        public BoardingpassDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BoardingpassDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(BoardingpassDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
