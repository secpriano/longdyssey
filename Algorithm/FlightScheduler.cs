using BLL.Container;
using BLL.Entity;
using DAL;
using ExceptionHandler;
using IL.Interface.DAL;

namespace Algorithm
{
    public class FlightScheduler
    {
        public FlightSchedule FlightSchedule { private get; set; }
        public Spaceship Spaceship { private get; set; }
        public List<AstronomicalObject> Route { get; set; }
        private DateTime DepartureTime;
        public List<Flight> NeededFlights { get; } = new();
        private List<Flight> AllFlights  = new();

        public List<uint> spaceshipsOnAO { get; } = new();
        private readonly IGateDAL gateDb;
        private readonly IFlightScheduleDAL flightScheduleDb;
        private readonly IFlightDAL flightDb;
        
        public FlightScheduler(IGateDAL gateDAL, IFlightScheduleDAL flightScheduleDAL, IFlightDAL flightDAL)
        {
            gateDb = gateDAL;
            flightScheduleDb = flightScheduleDAL;
            flightDb = flightDAL;
        }

        public void InsertFlightSchedule(string name, DateTime startDate, DateTime endDate)
        {
            // if null, then string is 'EMPTY'
            name ??= "EMPTY";

            DateTime presentDate = DateTime.Now;
            
            // if date is today, then set present time to startDate
            if (presentDate.Date == startDate)
            {
                TimeSpan time = presentDate.TimeOfDay;
                time = TimeSpan.FromMinutes(Math.Ceiling(time.TotalMinutes));
                startDate = startDate.Date + time;
            }
            
            // if there are invalid inputs, then throw InvalidInputException
            if (startDate < presentDate ||
                startDate != endDate ||
                name == "EMPTY" || name == "")
            {
                List<(string Error, string Fix)> errorAndFixMessages = new();

                // start date and end date must be a week apart and start date must be today or later
                if (startDate < presentDate ||
                    startDate != endDate ||
                    startDate.Date.AddDays(7) < endDate.Date)
                {
                    errorAndFixMessages.Add((Error: $"Invalid start date '{startDate}' and end date '{endDate}'", Fix: "Start date must be today or later and end date must be a week after start date"));
                }

                // name must not be empty
                if (name == "EMPTY" || name == "")
                {
                    errorAndFixMessages.Add((Error: $"Invalid name '{name}'", Fix: "Name must not be empty"));
                }

                throw new InvalidInputException(errorAndFixMessages);
            }

            try
            {
                flightScheduleDb.Insert(new FlightSchedule(name, startDate, endDate).GetDTO());
            }
            catch (DALexception e)
            {
                throw new ErrorResponse(e.ErrorType);
            }
        }
        
        public FlightSchedule GetByName(string name)
        {
            return new(flightScheduleDb.GetByName(name));
        }

        public void GenerateFlightsFromFlightSchedule(ISpaceshipDAL spaceshipDb, FlightSchedule flightSchedule, string selectedSpaceshipName, List<AstronomicalObject> route)
        {
            FlightSchedule = flightSchedule; 
            Spaceship = new(spaceshipDb.GetAll().FirstOrDefault(spaceship => spaceship.Name == selectedSpaceshipName));
            Route = route;
            DepartureTime = (DateTime)flightSchedule.StartDate;

            CalculateOutwardAndReturnFlightsStartingDepartureTimes();

            /// SQL
            flightDb.InsertFlightsFromFlightSchedule(AllFlights.Select(flight => flight.GetDTO()).ToList());
        }
        
        public void CalculateOutwardAndReturnFlightsStartingDepartureTimes()
        {
            double distance;
            decimal travelTimeHour;

            for (byte i = 0; i < Route.Count - 1; i++)
            {
                distance = CalculateDistance(Route[i], Route[i + 1]);
                travelTimeHour = CalculateTravelTimeHour(distance);
                CalculateSpaceshipsPerAO(travelTimeHour);
                CalculateOutwardStartingDepartureTimes(i);
            }
            CalculateReturnStartingDepartureTimes();

            CalculateDepartureTimes();
        }

        // Should be all private from line 66 to 182 but made public for testing purposes
        public static double CalculateDistance(AstronomicalObject origin, AstronomicalObject destination)
        {
            return ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out _));
        }

        public const int SecondsPerHour = 3600;
        public const decimal AstronomicalUnitInKilometers = 149597870.7M;
        public const decimal CInKilometers = 299792.458M;
        public static decimal AUtoKm(decimal distanceInKm) => distanceInKm * AstronomicalUnitInKilometers;

        public decimal CalculateTravelTimeHour(double distance)
        {
            decimal flightDurationSecond = AUtoKm((decimal)distance) / (Spaceship.Speed * CInKilometers);
            return flightDurationSecond / SecondsPerHour;
        }
        
        public void CalculateSpaceshipsPerAO(decimal travelTimeHour)
        {
            spaceshipsOnAO.Add((uint)Math.Ceiling(travelTimeHour / 8));
        }

        public readonly TimeSpan travelInterval = TimeSpan.FromHours(8);

        public void CalculateOutwardStartingDepartureTimes(byte i)
        {
            Gate originGate = GetGateByAstronomicalObjectName(Route[i].Name);
            Gate destinationGate = GetGateByAstronomicalObjectName(Route[i + 1].Name);
            DateTime nextDepartureTime = (DateTime)FlightSchedule.StartDate;

            // Keep creating flights until all spaceships are used
            for (int j = 0; j <= spaceshipsOnAO[i]; j++)
            {
                // Create a new flight and add it to the list
                CreateFlight(originGate, destinationGate, nextDepartureTime, $"{originGate.Spaceport.Name}{j}{originGate.Name}");
                nextDepartureTime = nextDepartureTime.Add(travelInterval);
            }
        }

        public void CalculateReturnStartingDepartureTimes()
        {
            for (int i = Route.Count - 1; i > 0; i--)
            {
                Gate originGate = GetGateByAstronomicalObjectName(Route[i].Name);
                Gate destinationGate = GetGateByAstronomicalObjectName(Route[i - 1].Name);
                DateTime nextDepartureTime = (DateTime)FlightSchedule.StartDate;

                // Keep creating flights until all spaceships are used
                for (int j = 0; j <= spaceshipsOnAO[i - 1]; j++)
                {
                    // Create a new flight and add it to the list
                    CreateFlight(originGate, destinationGate, nextDepartureTime, $"{originGate.Spaceport.Name}{j}{originGate.Name}");
                    nextDepartureTime = nextDepartureTime.Add(travelInterval);
                }
            }
        }

        public Gate GetGateByAstronomicalObjectName(string name)
        {
            return new(gateDb.GetByAstronomicalObjectName(name));
        }

        public void CreateFlight(Gate originGate, Gate destinationGate, DateTime nextDepartureTime, string flightNumber)
        {
            NeededFlights.Add(new(
                nextDepartureTime,
                0,
                flightNumber,
                originGate,
                destinationGate,
                Spaceship,
                FlightSchedule
            ));
        }

        public void CalculateDepartureTimes()
        {
            TimeSpan timeMinutes = TimeSpan.FromMinutes(5);

            NeededFlights.ForEach(flight =>
            {
                DepartureTime = flight.DepartureTime;

                // Keep creating flights until the departure time is in the future
                while (DepartureTime < FlightSchedule.EndDate)
                {
                    // Create a new flight and add it to the list
                    AllFlights.Add(new(
                        flight.DepartureTime,
                        flight.Status,
                        flight.FlightNumber,
                        flight.OriginGate,
                        flight.DestinationGate,
                        flight.Spaceship,
                        flight.FlightSchedule
                        )
                    );

                    // Swap gate for outward or return flight
                    (flight.DestinationGate, flight.OriginGate) = (flight.OriginGate, flight.DestinationGate);

                    // Set the next departure time to 8 hours after the current one
                    double timeHour = (double)CalculateTravelTimeHour(CalculateDistance(flight.DestinationGate.Spaceport.AstronomicalObject, flight.OriginGate.Spaceport.AstronomicalObject));

                    DepartureTime = DepartureTime.AddHours(timeHour);
                    DepartureTime = DepartureTime.AddMinutes(30);

                    // Rounding nearest 5 min
                    flight.DepartureTime = RoundOffTime(DepartureTime, timeMinutes);
                }
            });
        }

        public static DateTime RoundOffTime(DateTime time, TimeSpan timeMinutes)
        {
            var ticks = (time.Ticks + (timeMinutes.Ticks / 2) + 1) / timeMinutes.Ticks;
            return new DateTime(ticks * timeMinutes.Ticks, time.Kind);
        }
    }
}
