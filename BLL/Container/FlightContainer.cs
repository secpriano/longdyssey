using BLL.Entity;
using IL.DTO;
using IL.Interface.DAL;
using System.Data;

namespace BLL.Container
{
    public class FlightContainer
    {
        private readonly IFlightDAL Db;

        public FlightContainer(IFlightDAL db)
        {
            Db = db;
        }

        public void Add(Flight flight) 
        {
            FlightDTO dto = flight.GetDTO();
            Db.Insert(dto);
        
        }

        public List<Flight> GetAll()
        {
            List<Flight> DTOs = new();

            Db.GetAll().ForEach(flightDTO => 
            {
                DTOs.Add(new(flightDTO));
            });
            return DTOs;
        }

        public Flight GetByID(long id)
        {
            return new(Db.GetById(id));
        }

        public bool DeleteByID(long id)
        {
            return Db.Delete(id);
        }
    }
}
