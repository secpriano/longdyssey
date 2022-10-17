using BLL.Entity;
using IL.DTO;
using IL.Interface.DAL;
using System.Data;

namespace BLL.Container
{
    public class FlightContainer
    {
        private readonly IFlightDAL db;

        public FlightContainer(IFlightDAL data)
        {
            db = data;
        }

        public void Add(Flight flight) 
        {
            FlightDTO dto = flight.GetDTO();
            db.Insert(dto);
        
        }

        public List<Flight> GetAll()
        {
            List<Flight> DTOs = new();

            db.GetAll().ForEach(flightDTO => 
            {
                DTOs.Add(new(flightDTO));
            });
            return DTOs;
        }
    }
}
