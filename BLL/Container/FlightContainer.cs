using BLL.Entity;
using DAL;
using ExceptionHandler;
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

            return Db.InsertFlightsFromFlightSchedule(flightDtos);
        }

        public List<Flight> GetAll()
        {
            List<Flight> flights =
                Db.GetAll()
                .Select(flightDTO => new Flight(flightDTO)).ToList();

            return flights;
        }

        public List<Flight> SearchFlights(SpaceportContainer spaceportContainer, DateTime leaveDate, string originAOandSpaceportName, string destinationAOandSpaceportName, long amountSeats)
        {
            // if null, then string is 'EMPTY'
            originAOandSpaceportName ??= "EMPTY";
            destinationAOandSpaceportName ??= "EMPTY";

            DateTime presentDate = DateTime.Now;
            
            // if date is today, then set present time to leaveDate
            if (presentDate.Date == leaveDate)
            {
                TimeSpan time = presentDate.TimeOfDay;
                time = TimeSpan.FromMinutes(Math.Ceiling(time.TotalMinutes));
                leaveDate = leaveDate.Date + time;
            }
            
            Dictionary<string, long> spaceports = spaceportContainer.GetAll()
                .ToDictionary(spaceport => $"{spaceport.AstronomicalObject.Name} | {spaceport.Name}", spaceport => spaceport.Id);

            // if there are invalid inputs, then throw InvalidInputException
            if (leaveDate < presentDate || 
                !spaceports.TryGetValue(originAOandSpaceportName, out long originSpaceportId) || 
                !spaceports.TryGetValue(destinationAOandSpaceportName, out long destinationSpaceportId) ||
                originSpaceportId == destinationSpaceportId || 
                amountSeats < 1 || amountSeats > 10)
            {
                List<(string Error, string Fix)> errorAndFixMessages = new();

                if (leaveDate < presentDate)
                {
                    errorAndFixMessages.Add((
                        Error: $"Leave date '{leaveDate}' can not be earlier than {presentDate}.",
                        Fix: "Please select a future date."));
                }
                
                if (!spaceports.TryGetValue(originAOandSpaceportName, out originSpaceportId))
                {
                    errorAndFixMessages.Add((
                        Error: $"Origin spaceport '{originAOandSpaceportName}' does not exist.",
                        Fix: "Please select a valid origin spaceport from the list."));
                }

                if (!spaceports.TryGetValue(destinationAOandSpaceportName, out destinationSpaceportId))
                {
                    errorAndFixMessages.Add((
                        Error: $"Destination spaceport '{destinationAOandSpaceportName}' does not exist.",
                        Fix: "Please select a valid destination spaceport from the list."));
                }

                if (amountSeats < 1)
                {
                    errorAndFixMessages.Add((
                        Error: $"Amount seat '{amountSeats}' can not be less than 1.",
                        Fix: "Please select a number greater than 0."));
                }
                
                if (amountSeats > 10)
                {
                    errorAndFixMessages.Add((
                        Error: $"Amount seats '{amountSeats}' can not be higher than 10.",
                        Fix: "Please select a number less than 11."));
                }

                if (originSpaceportId == destinationSpaceportId)
                {
                    errorAndFixMessages.Add((
                        Error: $"Origin spaceport '{originAOandSpaceportName}' and destination spaceport '{destinationAOandSpaceportName}' can not be the same.",
                        Fix: "Please select a different destination spaceport."));
                }

                throw new InvalidInputException(errorAndFixMessages);
            }

            try
            {
                List<Flight> flights =
                    Db.SearchFlights(leaveDate, originSpaceportId, destinationSpaceportId, amountSeats)
                    .Select(flightDTO => new Flight(flightDTO)).ToList();

                return flights;
            }
            catch (DALexception e)
            {
                throw new ErrorResponse(e.ErrorType);
            }
        }
        
        public Flight GetByID(long id) => new(Db.GetById(id));

        public bool DeleteByID(long id) => Db.DeleteByID(id);
    }
}
