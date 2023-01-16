using ExceptionHandler;
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
            new(1, FlightData.flights[0], UserData.users[0], 5),
            new(2, FlightData.flights[0], UserData.users[3], 40)
        };

        public long FlightId { get; private set; }
        public long UserId { get; private set; }
        public long Seat { get; private set; }

        public bool BookSeatFromFlight(long seat, long flightId, long userId)
        {
            FlightId = flightId;
            UserId = userId;
            Seat = seat;

            if (boardingpasses.Exists(boardingpass => boardingpass.Flight.Id == flightId && boardingpass.Seat == Seat))
            {
                throw new DALexception(ErrorType.SeatTaken, "Seat is already taken");
            }
            
            BoardingpassDTO boardingpass = new(FlightData.GetById(flightId), UserData.GetById(userId), seat);
            boardingpass.Id = boardingpasses.Count + 1;
            boardingpasses.Add(boardingpass);

            return boardingpasses.Contains(boardingpass);
        }

        public bool DeleteByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<BoardingpassDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BoardingpassDTO> GetBoardingpassesByFlightId(long id)
        {
            return boardingpasses.FindAll(boardingpasses => boardingpasses.Flight.Id == id);
        }

        public BoardingpassDTO GetById(long id)
        {
            return boardingpasses.Find(boardingpass => boardingpass.Id == id);
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
