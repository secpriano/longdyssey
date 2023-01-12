using BLL.Container;
using BLL.Entity;
using DAL;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Algorithm
{
    public class FlightScheduler
    {
        public string Name { get; set; }
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<Flight> NeededFlights { get; set; }
        public List<Flight> AllFlights { get; set; }
        public FlightSchedule FlightSchedule { get; set; }

        private readonly List<uint> spaceshipsOnAO = new();

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

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

            NeededFlights = new List<Flight>();
            AllFlights = new List<Flight>();

            //flightScheduleController.Insert(new(Name, StartDate, EndDate));
            //FlightSchedule = flightScheduleController.GetByName(Name);
            FlightSchedule = new(10, "test", StartDate, EndDate);

            GenerateFlightSchedule();
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
            List<string> flights = new();
            foreach (Flight flight in AllFlights)
            {
                flights.Add($"{flight.OriginGate.Spaceport.AstronomicalObject.Name} => {flight.DestinationGate.Spaceport.AstronomicalObject.Name} | {flight.DepartureTime}");
            }
            /// SQL
            //flightController.InsertFlightSchedule(NeededFlights);
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

        private void CalculateOutwardStartingDepartureTimes(byte i)
        {
            Gate originGate = gateController.GetByAstronomicalObjectName(Route[i].Name);
            Gate destinationGate = gateController.GetByAstronomicalObjectName(Route[i + 1].Name);

            // Keep creating flights until all spaceships are used
            for (int j = 0; j <= spaceshipsOnAO[i]; j++)
            {
                // Create a new flight and add it to the list
                NeededFlights.Add(new(
                    DepartureTime, 
                    0,
                    originGate,
                    destinationGate, 
                    Spaceship,
                    FlightSchedule
                    )
                );

                // Set the next departure time to 8 hours after the current one
                DepartureTime = DepartureTime.AddHours(8);
            }

            DepartureTime = StartDate;
        }


        private void CalculateReturnStartingDepartureTimes()
        {
            for (int i = Route.Count - 1; i > 0; i--)
            {
                Gate originGate = gateController.GetByAstronomicalObjectName(Route[i].Name);
                Gate destinationGate = gateController.GetByAstronomicalObjectName(Route[i - 1].Name);

                // Keep creating flights until all spaceships are used
                for (int j = 0; j <= spaceshipsOnAO[i - 1]; j++)
                {
                    // Create a new flight and add it to the list
                    NeededFlights.Add(new(
                        DepartureTime,
                        0,
                        originGate,
                        destinationGate,
                        Spaceship,
                        FlightSchedule
                        )
                    );

                    // Set the next departure time to 8 hours after the current one
                    DepartureTime = DepartureTime.AddHours(8);
                }

                DepartureTime = StartDate;
            }
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

                    // Rounding
                    long ticks = (DepartureTime.Ticks + (timeMinutes.Ticks / 2) + 1) / timeMinutes.Ticks;

                    flight.DepartureTime = new DateTime(ticks * timeMinutes.Ticks, DepartureTime.Kind);
                }
            });
        }
    }
}
