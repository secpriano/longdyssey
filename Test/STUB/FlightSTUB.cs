using IL.DTO;
using IL.Interface.DAL;
using Test.STUB;

namespace Test.STUB
{
    public class FlightSTUB : IFlightDAL
    {
        static GateSTUB GateData = new();
        static SpaceshipSTUB SpaceshipData = new();

        public List<FlightDTO> DTOs = new()
        {
            new(1, new(2050, 12, 21), 1, "EAUSNY4785", GateData.gates[0], GateData.gates[20], SpaceshipData.spaceships[4])
        };

        public bool DeleteByID(long id)
        {
            FlightDTO DTO = DTOs[(int)id];
            DTOs.RemoveAt((int)id);

            return !DTOs.Contains(DTO);
        }

        public List<FlightDTO> GetAll() => DTOs;

        public FlightDTO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(FlightDTO entity)
        {
            DTOs.Add(entity);

            return DTOs.Contains(entity);
        }

        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originGate, long destinationGate, long travelers)
        {
            throw new NotImplementedException();
        }

        public bool Update(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
