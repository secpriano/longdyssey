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

        public bool DeleteByID(long id)
        {
            foreach (var DTO in flights)
            {
                if (DTO.Id == id)
                {
                    flights.RemoveAt((int)id);
                    return true;
                }
            }

            return false;
        }

        public List<FlightDTO> GetAll() => flights;

        public FlightDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FlightDTO entity)
        {
            flights.Add(entity);

            return flights.Contains(entity);
        }

        public bool InsertFlightSchedule(List<FlightDTO> entities)
        {
            throw new NotImplementedException();
        }

        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originSpaceportId, long destinationSpaceportId, long amountTravelers)
        {
            List<FlightDTO> searchList = new();
            flights.ForEach(DTO =>
            {
                if (DTO.DepartureTime == leaveDate && DTO.OriginGate.Spaceport.Id == originSpaceportId && DTO.DestinationGate.Spaceport.Id == destinationSpaceportId && DTO.Spaceship.Seat >= amountTravelers)
                {
                    searchList.Add(DTO);
                }
            });
            return searchList;
        }

        public bool Update(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
