using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IFlightDAL
    {
        public List<FlightDTO> GetAll();
        public List<FlightDTO> SearchFlights(DateTime leaveDate, long originSpaceportId, long destinationSpaceportId, long amountSeats);
        public FlightDTO GetById(long id);
        public List<FlightDTO> GetByFlightScheduleId(long id);
        public bool Insert(FlightDTO entity);
        public bool InsertFlightsFromFlightSchedule(List<FlightDTO> entities);
        public bool Update(FlightDTO entity);
        public bool DeleteByID(long id);
    }
}
