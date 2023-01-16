namespace IL.DTO
{
    public class FlightDTO
    {
        public long Id { get; set; }
        public DateTime DepartureTime { get; }
        public long Status { get; }
        public string FlightNumber { get; }
        public GateDTO OriginGate { get; }
        public GateDTO DestinationGate { get; }
        public SpaceshipDTO Spaceship { get; }
        public FlightScheduleDTO? FlightSchedule { get; }

        public FlightDTO(long id, DateTime departureTime, long status, string flightNumber, GateDTO originGate, GateDTO destinationGate, SpaceshipDTO spaceship, FlightScheduleDTO? flightSchedule)
        {
            Id = id;
            DepartureTime = departureTime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;
            FlightSchedule = flightSchedule;
        }

        public FlightDTO(DateTime departureTime, long status, string flightNumber, GateDTO originGate, GateDTO destinationGate, SpaceshipDTO spaceship, FlightScheduleDTO? flightSchedule)
        {
            DepartureTime = departureTime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;
            FlightSchedule = flightSchedule;
        }
    }
}
