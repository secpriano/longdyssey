using BLL.Container;
using BLL.Entity;
using DAL;

namespace Algorithm
{
    public class FlightScheduler
    {
        public string Name { get; set; }
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<Flight> NeededFlights { get; } = new();
        public List<Flight> AllFlights { get; } = new();
        public FlightSchedule FlightSchedule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private readonly List<uint> spaceshipsOnAO = new();
        private readonly GateContainer gateController = new(new GateDAL());
        private readonly FlightScheduleContainer flightScheduleController = new(new FlightScheduleDAL());
        private readonly FlightContainer flightController = new(new FlightDAL());

        public FlightScheduler(string name, Spaceship spaceship, List<AstronomicalObject> route, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Spaceship = spaceship;
            Route = route;
            DepartureTime = startDate;
            StartDate = startDate;
            EndDate = endDate;
            InsertFlightSchedule();
            FlightSchedule = flightScheduleController.GetByName(Name);
            GenerateFlightSchedule();
        }

        private void InsertFlightSchedule()
        {
            flightScheduleController.Insert(new FlightSchedule(Name, StartDate, EndDate));
        }

        private void GenerateFlightSchedule()
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

            /// SQL
            flightController.InsertFlightSchedule(AllFlights);
        }

        private static double CalculateDistance(AstronomicalObject origin, AstronomicalObject destination)
        {
            return ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out double[] _));
        }

        private const int SecondsPerHour = 3600;
        private const decimal AstronomicalUnitInKilometers = 149597870.7M;
        private const decimal CInKilometers = 299792.458M;
        private static decimal AUtoKm(decimal distanceInKm) => distanceInKm * AstronomicalUnitInKilometers;

        private decimal CalculateTravelTimeHour(double distance)
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
            var originGate = GetGateByAstronomicalObjectName(Route[i].Name);
            var destinationGate = GetGateByAstronomicalObjectName(Route[i + 1].Name);
            var nextDepartureTime = StartDate;

            // Keep creating flights until all spaceships are used
            for (int j = 0; j <= spaceshipsOnAO[i]; j++)
            {
                // Create a new flight and add it to the list
                CreateFlight(originGate, destinationGate, nextDepartureTime);
                nextDepartureTime = nextDepartureTime.Add(travelInterval);
            }
        }

        private void CalculateReturnStartingDepartureTimes()
        {
            for (int i = Route.Count - 1; i > 0; i--)
            {
                var originGate = GetGateByAstronomicalObjectName(Route[i].Name);
                var destinationGate = GetGateByAstronomicalObjectName(Route[i - 1].Name);
                var nextDepartureTime = StartDate;

                // Keep creating flights until all spaceships are used
                for (int j = 0; j <= spaceshipsOnAO[i - 1]; j++)
                {
                    // Create a new flight and add it to the list
                    CreateFlight(originGate, destinationGate, nextDepartureTime);
                    nextDepartureTime = nextDepartureTime.Add(travelInterval);
                }
            }
        }

        private Gate GetGateByAstronomicalObjectName(string name)
        {
            return gateController.GetByAstronomicalObjectName(name);
        }

        private void CreateFlight(Gate originGate, Gate destinationGate, DateTime nextDepartureTime)
        {
            NeededFlights.Add(new(
                nextDepartureTime,
                0,
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
                while (DepartureTime < EndDate)
                {
                    // Create a new flight and add it to the list
                    AllFlights.Add(new(
                        flight.DepartureTime,
                        flight.Status,
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
