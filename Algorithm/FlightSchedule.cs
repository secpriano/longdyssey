using BLL.Container;
using BLL.Entity;
using DAL;

namespace Algorithm
{
    public class FlightSchedule
    {
        public string Name { get; set; }
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<Flight> Flights { get; set; }
        public BLL.Entity.FlightSchedule E_FlightSchedule { get; set; }

        private readonly List<double> distances = new();
        private readonly List<double> travelTimes = new();
        private readonly List<DateTime> departureTimes = new();

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private readonly GateContainer gateController = new(new GateDAL());
        private readonly FlightScheduleContainer flightScheduleController = new(new FlightScheduleDAL());
        private readonly FlightContainer flightController = new(new FlightDAL());

        public FlightSchedule(string name, Spaceship spaceship, List<AstronomicalObject> route, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Spaceship = spaceship;
            Route = route;
            DepartureTime = startDate;
            StartDate = startDate;
            EndDate = endDate;

            departureTimes.Add(DepartureTime);
            Flights = new List<Flight>();

            flightScheduleController.Insert(new(Name, StartDate, EndDate));
            E_FlightSchedule = flightScheduleController.GetByName(Name);

            GenerateFlightSchedule();
        }

        private void GenerateFlightSchedule()
        {
            for (byte i = 0; i < Route.Count - 1; i++)
            {
                CalculateDistances(i);
                CalculateTravelTimes(i);
                CalculateOutwardDepartureTimes(i);
            }
            CalculateReturnDepartureTimes();

            /// SQL
            flightController.InsertFlightSchedule(Flights);
        }

        private void CalculateDistances(byte i)
        {
            AstronomicalObject origin = Route[i];
            AstronomicalObject destination = Route[i + 1];
            double distance = ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out double[] _));
            distances.Add(distance);
        }

        private void CalculateTravelTimes(byte i)
        {
            travelTimes.Add(distances[i] / (double)Spaceship.Speed);
        }

        private void CalculateOutwardDepartureTimes(byte i)
        {
            Gate originGate = gateController.GetByAstronomicalObjectName(Route[i].Name);
            Gate destinationGate = gateController.GetByAstronomicalObjectName(Route[i + 1].Name);

            // Keep creating flights until the departure time is in the future
                while (DepartureTime < EndDate)
                {
                    // Create a new flight and add it to the list
                    Flights.Add(new(
                        DepartureTime, 
                        0,
                        originGate,
                        destinationGate, 
                        Spaceship,
                        E_FlightSchedule
                        )
                    );

                    // Set the next departure time to 8 hours after the current one
                    DepartureTime = DepartureTime.AddHours(8);
                }
                DepartureTime = StartDate;
            
        }
            
        private void CalculateReturnDepartureTimes()
        {
            for (int i = Route.Count - 1; i > 0; i--)
            {
                Gate originGate = gateController.GetByAstronomicalObjectName(Route[i].Name);
                Gate destinationGate = gateController.GetByAstronomicalObjectName(Route[i - 1].Name);

                while (DepartureTime < EndDate)
                {
                    // Create a new flight and add it to the list
                    Flights.Add(new(
                        DepartureTime,
                        0,
                        originGate,
                        destinationGate,
                        Spaceship,
                        E_FlightSchedule
                        )
                    );

                    // Set the next departure time to 8 hours after the current one
                    DepartureTime = DepartureTime.AddHours(8);
                }
                DepartureTime = StartDate;
            }
        }
    }
}
