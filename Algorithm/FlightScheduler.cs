using BLL.Container;
using BLL.Entity;
using DAL;
using IL.Interface.DAL;

namespace Algorithm
{
    public class FlightScheduler
    {
        private FlightSchedule FlightSchedule;
        public Spaceship Spaceship { private get; set; }
        private List<AstronomicalObject> Route;
        private DateTime DepartureTime;
        private List<Flight> NeededFlights = new();
        private List<Flight> AllFlights  = new();

        private readonly List<uint> spaceshipsOnAO = new();
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
            //TODO: Add validation
            flightScheduleDb.Insert(new FlightSchedule(name, startDate, endDate).GetDTO());
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

            /// SQL
            flightDb.InsertFlightsFromFlightSchedule(AllFlights.Select(flight => flight.GetDTO()).ToList());
        }

        private static double CalculateDistance(AstronomicalObject origin, AstronomicalObject destination)
        {
            return ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out double[] _));
        }

        private const int SecondsPerHour = 3600;
        private const decimal AstronomicalUnitInKilometers = 149597870.7M;
        private const decimal CInKilometers = 299792.458M;
        private static decimal AUtoKm(decimal distanceInKm) => distanceInKm * AstronomicalUnitInKilometers;

        public decimal CalculateTravelTimeHour(double distance)
        {
            decimal flightDurationSecond = AUtoKm((decimal)distance) / (Spaceship.Speed * CInKilometers);
            return flightDurationSecond / SecondsPerHour;
        }
        
        private void CalculateSpaceshipsPerAO(decimal travelTimeHour)
        {
            spaceshipsOnAO.Add((uint)Math.Ceiling(travelTimeHour / 8));
        }

        private readonly TimeSpan travelInterval = TimeSpan.FromHours(8);

        private void CalculateOutwardStartingDepartureTimes(byte i)
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

        private void CalculateReturnStartingDepartureTimes()
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

        private Gate GetGateByAstronomicalObjectName(string name)
        {
            return new(gateDb.GetByAstronomicalObjectName(name));
        }

        private void CreateFlight(Gate originGate, Gate destinationGate, DateTime nextDepartureTime, string flightNumber)
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

        private void CalculateDepartureTimes()
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

        private static DateTime RoundOffTime(DateTime time, TimeSpan timeMinutes)
        {
            var ticks = (time.Ticks + (timeMinutes.Ticks / 2) + 1) / timeMinutes.Ticks;
            return new DateTime(ticks * timeMinutes.Ticks, time.Kind);
        }
    }
}
