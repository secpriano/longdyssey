using BLL.Entity;

namespace IL.DTO
{
    public class FlightDTO
    {
        public ulong Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Status { get; set; }
        public string FlightNumber { get; set; }
        public GateDTO OriginGate { get; set; }
        public GateDTO DestinationGate { get; set; }
        public SpaceshipDTO Spaceship { get; set; }

        public FlightDTO(ulong id, DateTime departureTime, string status, string flightNumber, GateDTO originGate, GateDTO destinationGate, SpaceshipDTO spaceship)
        {
            Id = id;
            DepartureTime = departureTime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;
        }
    }
}
