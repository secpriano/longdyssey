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

        public Result<List<Flight>> SearchFlights(SpaceportContainer spaceportContainer, DateTime leaveDate, string originAOandSpaceportName, string destinationAOandSpaceportName, long amountTravelers)
        {
            Dictionary<string, long> spaceports = spaceportContainer.GetAll()
                .ToDictionary(spaceport => $"{spaceport.AstronomicalObject.Name} | {spaceport.Name}", spaceport => spaceport.Id);

            if (leaveDate < DateTime.Now || 
                !spaceports.TryGetValue(originAOandSpaceportName, out long originSpaceportId) || 
                !spaceports.TryGetValue(destinationAOandSpaceportName, out long destinationSpaceportId) || 
                amountTravelers < 1 || amountTravelers > 10)
            {
                Result<List<Flight>> result = new()
                {
                    errorAndFixMessages = new()
                };

                if (leaveDate < DateTime.Now)
                {
                    result.errorAndFixMessages.Add(
                        (
                            Error: $"Leave date '{leaveDate}' can not be earlier than present date.",
                            Fix: "Please select a date today or in the future."
                        )
                    );
                }

                if (!spaceports.TryGetValue(originAOandSpaceportName, out originSpaceportId))
                {
                    result.errorAndFixMessages.Add(
                        (
                            Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.",
                            Fix: "Please select a valid origin spaceport."
                        )
                    );
                }

                if (!spaceports.TryGetValue(destinationAOandSpaceportName, out destinationSpaceportId))
                {
                    result.errorAndFixMessages.Add(
                        (
                            Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.",
                            Fix: "Please select a valid destination spaceport."
                        )
                    );
                }

                if (amountTravelers < 1)
                {
                    result.errorAndFixMessages.Add(
                        (
                            Error: $"Travelers '{amountTravelers}' can not be less than 1.", 
                            Fix: "Please select a number greater than 0."
                        )
                    );
                }
                else
                {
                    result.errorAndFixMessages.Add(
                        (
                            Error: $"Travelers '{amountTravelers}' can not be higher than 10.",
                            Fix: "Please select a number less than 11."
                        )
                    );
                }

                return result;
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
                Result<List<Flight>> result = new()
                {
                    errorAndFixMessages = new List<(string Error, string Fix)>()
                    {
                        (Error: $"Error: {ex.Message}", Fix: "Possible fixes: Check SQL")
                    }
                };

                return result;
            }
        }
        public Flight GetByID(long id) => new(Db.GetById(id));

        public bool DeleteByID(long id) => Db.DeleteByID(id);
    }
}
