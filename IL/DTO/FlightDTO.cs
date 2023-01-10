namespace IL.DTO
{
    public class FlightDTO
    {
        public long Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public long Status { get; set; }
        public string FlightNumber { get; set; }
        public GateDTO OriginGate { get; set; }
        public GateDTO DestinationGate { get; set; }
        public SpaceshipDTO Spaceship { get; set; }
        public FlightScheduleDTO? FlightSchedule { get; set; }

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
