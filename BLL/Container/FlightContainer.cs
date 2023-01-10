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

        public bool InsertFlightSchedule(List<Flight> flights)
        {
            List<FlightDTO> flightDtos = 
                flights
                .Select(flight => flight.GetDTO()).ToList();

            return Db.InsertFlightSchedule(flightDtos);
        }

        public List<Flight> GetAll()
        {
            List<Flight> flights = 
                Db.GetAll()
                .Select(flightDTO => new Flight(flightDTO)).ToList();

            return flights;
        }

        public Result<List<Flight>> SearchFlights(SpaceportContainer spaceportContainer, DateTime leaveDate, string originAOandSpaceport, string destinationAOandSpaceport, long amountTravelers)
        {
            long originSpaceportId = 0;
            long destinationSpaceportId = 0;

            spaceportContainer.GetAll().ForEach(spaceport =>
            {
                string AOnameAndSpaceportName = $"{spaceport.AstronomicalObject.Name} | {spaceport.Name}";
                if (originAOandSpaceport == AOnameAndSpaceportName)
                {
                    originSpaceportId = spaceport.Id;
                }
                if (destinationAOandSpaceport == AOnameAndSpaceportName)
                {
                    destinationSpaceportId = spaceport.Id;
                }
            });

            if (originSpaceportId == 0 || destinationSpaceportId == 0)
            {
                return new Result<List<Flight>> { ErrorMessage = $"Error: invalid input", PossibleFixesMessage = $"Possible fixes: Select one from the dropdown menu" };
            }

            try
            {
                List<Flight> flights =
                    Db.SearchFlights(leaveDate, originSpaceportId, destinationSpaceportId, amountTravelers)
                    .Select(flightDTO => new Flight(flightDTO)).ToList();

                return new Result<List<Flight>> { Data = flights };
            }
            catch (Exception ex)
            {
                return new Result<List<Flight>> { ErrorMessage = $"Error: {ex.Message}" };
            }
        }
        public Flight GetByID(long id) => new(Db.GetById(id));

        public bool DeleteByID(long id) => Db.DeleteByID(id);
    }
}
