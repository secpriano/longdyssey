using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IFlightScheduleDAL
    {
        public bool Insert(FlightScheduleDTO entity);
        public FlightScheduleDTO GetByName(string name);
    }
}
