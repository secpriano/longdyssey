using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IFlightDAL
    {
        public List<FlightDTO> GetAll();
        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originGate, long destinationGate, long travelers);
        public FlightDTO GetById(long id);
        public bool Insert(FlightDTO entity);
        public bool Update(FlightDTO entity);
        public bool DeleteByID(long id);
    }
}
