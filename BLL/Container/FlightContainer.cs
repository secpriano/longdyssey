using BLL.Entity;
using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Container
{
    public class FlightContainer
    {
        private readonly IFlightDAL Db;

        public FlightContainer(IFlightDAL db)
        {
            Db = db;
        }

        public bool Add(Flight flight)
        {
            FlightDTO dto = flight.GetDTO();

            return Db.Insert(dto);
        }

        public List<Flight> GetAll()
        {
            List<Flight> flights = new();

            Db.GetAll().ForEach(flightDTO => 
            {
                flights.Add(new(flightDTO));
            });

            return flights;
        }

        public Flight GetByID(long id)
        {
            return new(Db.GetById(id));
        }

        public bool DeleteByID(long id)
        {
            return Db.DeleteByID(id);
        }
    }
}
