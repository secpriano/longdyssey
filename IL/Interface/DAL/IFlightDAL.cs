using IL.DTO;
using System.Data;

namespace IL.Interface.DAL
{
    public interface IFlightDAL
    {
        public List<FlightDTO> GetAll();
        public FlightDTO GetById(long id);
        public bool Insert(FlightDTO entity);
        public bool Update(FlightDTO entity);
        public bool Delete(long id);
    }
}
