using ExceptionHandler;
using IL.DTO;
using IL.Interface.DAL;

namespace Test.STUB
{
    public class FlightSTUB : IFlightDAL
    {
        static GateSTUB GateData = new();
        static SpaceshipSTUB SpaceshipData = new();

        public List<FlightDTO> flights = new()
        {
            new(1, new(2050, 12, 21), 1, "EAUSNY4785", GateData.gates[0], GateData.gates[20], SpaceshipData.spaceships[4], null)
        };

        public long FlightId { get; set; }
        public bool DeleteByID(long id)
        {
            FlightId = id;
            flights.RemoveAll(flights => flights.Id == id);

            return !flights.Exists(flights => flights.Id == id);
        }

        public List<FlightDTO> GetAll() => flights;

        public FlightDTO GetById(long id)
        {
            return flights.Find(flights => flights.Id == id);
        }

        public List<FlightDTO> GetByFlightScheduleId(long id)
        {
            FlightId = id;
             return flights.FindAll(flight => flight.FlightSchedule != null && flight.FlightSchedule.Id == id);
        }

        public bool Insert(FlightDTO entity)
        {
            flights.Add(entity);

            return flights.Contains(entity);
        }

        public bool InsertFlightsFromFlightSchedule(List<FlightDTO> entities)
        {
            entities.ForEach(flight => flights.Add(flight));
            return true;
        }
        
        public DateTime LeaveDate { get; private set; }
        public long OriginSpaceportId { get; private set; }
        public long DestinationSpaceportId { get; private set; }
        public long AmountSeats { get; private set; }
        
        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originSpaceportId, long destinationSpaceportId, long amountSeats)
        {
            LeaveDate = leaveDate;
            OriginSpaceportId = originSpaceportId;
            DestinationSpaceportId = destinationSpaceportId;
            AmountSeats = amountSeats;

            List<FlightDTO> searchedFlights = flights.FindAll(flights =>
                flights.DepartureTime == leaveDate &&
                flights.OriginGate.Spaceport.Id == originSpaceportId &&
                flights.DestinationGate.Spaceport.Id == destinationSpaceportId &&
                flights.Spaceship.Seat >= amountSeats);

            if (searchedFlights.Count == 0)
            {
                throw new DALexception(ErrorType.FlightsAreEmpty, "No DTOs found");
            }
            
            return searchedFlights;
        }

        public bool Update(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
