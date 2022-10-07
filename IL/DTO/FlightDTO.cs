namespace IL.DTO
{
    public class FlightDTO
    {
        private ulong departureTime;
        private object value1;
        private GateDTO gateDTO;
        private object value2;

        public ulong Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public ulong Status { get; set; }
        public string FlightNumber { get; set; }
        public GateDTO OriginGate { get; set; }
        public GateDTO DestinationGate { get; set; }
        public SpaceshipDTO Spaceship { get; set; }

        public FlightDTO(ulong id, DateTime departureTime, ulong status, string flightNumber, GateDTO originGate, GateDTO destinationGate, SpaceshipDTO spaceship)
        {
            Id = id;
            DepartureTime = departureTime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;
        }

        public FlightDTO(DateTime departureTime, ulong status, string flightNumber, GateDTO originGate, GateDTO destinationGate, SpaceshipDTO spaceship)
        {
            DepartureTime = departureTime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;

        }
    }
}
