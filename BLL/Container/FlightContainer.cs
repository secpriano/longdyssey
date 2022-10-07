using BLL.Entity;
using IL.DTO;
using IL.Interface.DAL;
using System.Data;

namespace BLL.Container
{
    public class FlightContainer
    {
        IFlightDAL Data;

        public FlightContainer(IFlightDAL data)
        {
            Data = data;
        }

        public void Add(Flight flight) 
        {
            FlightDTO dto = flight.GetDTO();
            Data.Insert(dto);
        }

        public DataTable GetAll()
        {
            return Data.GetAll();
        }
    }
}
