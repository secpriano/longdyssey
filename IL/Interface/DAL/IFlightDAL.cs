using IL.DTO;
using System.Data;

namespace IL.Interface.DAL
{
    public interface IFlightDAL
    {
        public DataTable GetAll();
        public FlightDTO GetById(ulong id);
        public bool Insert(FlightDTO entity);
        public bool Update(FlightDTO entity);
        public bool Delete(ulong id);
    }
}
