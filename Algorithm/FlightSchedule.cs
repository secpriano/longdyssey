using BLL.Container;
using BLL.Entity;
using DAL;
using System.Reflection.Metadata.Ecma335;

namespace Algorithm
{
    public class FlightSchedule
    {
        public string Name { get; set; }
        public Spaceship Spaceship { get; set; }
        public List<AstronomicalObject> Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<Flight> NeededFlights { get; set; }
        public List<Flight> AllFlights { get; set; }
        public BLL.Entity.FlightSchedule E_FlightSchedule { get; set; }

        private readonly List<double> distances = new();
        private readonly List<decimal> travelTimes = new();
        private readonly List<uint> spaceshipsOnAO = new();

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

            NeededFlights = new List<Flight>();
            AllFlights = new List<Flight>();

            //flightScheduleController.Insert(new(Name, StartDate, EndDate));
            //E_FlightSchedule = flightScheduleController.GetByName(Name);
            E_FlightSchedule = new(10, "test", StartDate, EndDate);

            GenerateFlightSchedule();
        }

        private void GenerateFlightSchedule()
        {
            for (byte i = 0; i < Route.Count - 1; i++)
            {
                CalculateDistances(i);
                CalculateTravelTimes(i);
                CalculateSpaceshipsPerAO(i);
                CalculateOutwardStartingDepartureTimes(i);
            }
            CalculateReturnStartingDepartureTimes();

            CalculateOutwardDepartureTimes();

            /// SQL
            //flightController.InsertFlightSchedule(NeededFlights);
        }

        private void CalculateDistances(byte i)
        {
            AstronomicalObject origin = Route[i];
            AstronomicalObject destination = Route[i + 1];
            double distance = ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out double[] _));
            distances.Add(distance);
        }

        private const int SecondsPerHour = 3600;
        private const decimal AstronomicalUnitInKilometers = 149597870.7M;
        private const decimal CInKilometers = 299792.458M;
        private static decimal AUtoKm(decimal distanceInKm) => distanceInKm * AstronomicalUnitInKilometers;

        private void CalculateTravelTimes(byte i)
        {
            decimal flightDurationInSeconds = AUtoKm((decimal)distances[i]) / (Spaceship.Speed * CInKilometers);
            travelTimes.Add(flightDurationInSeconds / SecondsPerHour);
        }

        private void CalculateSpaceshipsPerAO(byte i)
        {
            spaceshipsOnAO.Add((uint)Math.Ceiling(travelTimes[i] / 8));
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
                    E_FlightSchedule
                    )
                );

                // Set the next departure time to 8 hours after the current one
                DepartureTime = DepartureTime.AddHours(8);
            }

            DepartureTime = StartDate;
        }

        private void CalculateOutwardDepartureTimes()
        {
            NeededFlights.ForEach(flight =>
            {
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

                    // Set the next departure time to 8 hours after the current one
                    DepartureTime = DepartureTime.AddHours((double)(8 + aCalculateTravelTimesInHours(aCalculateDistance(flight.OriginGate.Spaceport.AstronomicalObject, flight.DestinationGate.Spaceport.AstronomicalObject))));
                    flight.DepartureTime = flight.DepartureTime.AddHours(DepartureTime.Hour);
                }

                DepartureTime = flight.DepartureTime;
            });
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
                        E_FlightSchedule
                        )
                    );

                    // Set the next departure time to 8 hours after the current one
                    DepartureTime = DepartureTime.AddHours(8);
                }

                DepartureTime = StartDate;
            }
        }

        /*        private void CalculateReturnStartingDepartureTimes()
                {
                    // Return flight depart 1 hour later than arrival
                    DepartureTime = DepartureTime.AddHours(1);

                    for (int i = Route.Count - 1; i > 0; i--)
                    {
                        Gate originGate = gateController.GetByAstronomicalObjectName(Route[i].Name);
                        Gate destinationGate = gateController.GetByAstronomicalObjectName(Route[i - 1].Name);

                        while (DepartureTime < EndDate)
                        {
                            // Create a new flight and add it to the list
                            NeededFlights.Add(new(
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
        */

        private double aCalculateDistance(AstronomicalObject origin, AstronomicalObject destination)
        {
            return ShortestRoute.CalculateFlightDistance(origin.SphericalToCartesianCoordinates(out _), destination.SphericalToCartesianCoordinates(out double[] _));
        }

        private decimal aCalculateTravelTimesInHours(double distance)
        {
            decimal flightDurationInSeconds = AUtoKm((decimal)distance) / (Spaceship.Speed * CInKilometers);
            return flightDurationInSeconds / SecondsPerHour;
        }

    }
}
