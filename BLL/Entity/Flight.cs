using IL.DTO;

namespace BLL.Entity
{
    public class Flight
    {
        public ulong Id { get; set; }
        public DateTime Departuretime { get; set; }
        public ulong Status { get; set; }
        public string FlightNumber { get; set; }
        public Gate OriginGate { get; set; }
        public Gate DestinationGate { get; set; }
        public Spaceship Spaceship { get; set; }

        public Flight(DateTime departuretime, ulong status, Gate originGate, Gate destinationGate, Spaceship spaceship)
        {
            Departuretime = departuretime;
            Status = status;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;

            GenerateFlightNumber();
        }

        public Flight(FlightDTO dto)
        {
            Id = dto.Id;
            Departuretime = dto.DepartureTime;
            Status = dto.Status;
            FlightNumber = dto.FlightNumber;
            OriginGate = new(dto.OriginGate);
            DestinationGate = new(dto.DestinationGate);
            Spaceship = new(dto.Spaceship);
        }
        public void GenerateFlightNumber()
        {
            FlightNumber = "";
        }

        public double CalcuclateFlightDuration() 
        {
            double distanceBetweenSpaceport = Math.Sqrt(Math.Pow(OriginGate.Spaceport.X - DestinationGate.Spaceport.X, 2) + Math.Pow(OriginGate.Spaceport.Y - DestinationGate.Spaceport.Y, 2) + Math.Pow(OriginGate.Spaceport.Z - DestinationGate.Spaceport.Z, 2));

            //DateTime flightDuration = DateTime.Parse((distanceBetweenSpaceport / Spaceship.Speed).ToString());

            return distanceBetweenSpaceport;
        }

        public FlightDTO GetDTO()
        {
            SpaceportDTO spaceportV = new(OriginGate.Spaceport.Id, OriginGate.Spaceport.Name, OriginGate.Spaceport.X, OriginGate.Spaceport.Y, OriginGate.Spaceport.Z );
            GateDTO gateV = new(OriginGate.Id, OriginGate.Name, spaceportV);
            SpaceportDTO spaceportA = new(DestinationGate.Spaceport.Id, DestinationGate.Spaceport.Name, DestinationGate.Spaceport.X, DestinationGate.Spaceport.Y, DestinationGate.Spaceport.Z );
            GateDTO gateA = new(DestinationGate.Id, DestinationGate.Name, spaceportV);
            return new FlightDTO(Departuretime, Status, FlightNumber, gateV, gateA, new SpaceshipDTO(Spaceship.Id, Spaceship.Name, Spaceship.Seat, Spaceship.Speed, Spaceship.Role));
        }

    }
}
