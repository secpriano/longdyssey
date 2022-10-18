using IL.DTO;

namespace BLL.Entity
{
    public class Flight
    {
        public long Id { get; set; }
        public DateTime Departuretime { get; set; }
        public long Status { get; set; }
        public string FlightNumber { get; set; }
        public Gate OriginGate { get; set; }
        public Gate DestinationGate { get; set; }
        public Spaceship Spaceship { get; set; }

        public Flight(DateTime departuretime, long status, Gate originGate, Gate destinationGate, Spaceship spaceship)
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

        private void GenerateFlightNumber()
        {
            FlightNumber = "";
        }

        private double CalcuclateFlightDistance()
        {
            double[] originCoordinates = OriginGate.Spaceport.PointOfInterest.SphericalToCartesianCoordinates();

            double[] destinationCoordinates = DestinationGate.Spaceport.PointOfInterest.SphericalToCartesianCoordinates();

            return Math.Sqrt(
                Math.Pow(originCoordinates[(byte)Coordinates.X] - destinationCoordinates[(byte)Coordinates.X], 2)
                +
                Math.Pow(originCoordinates[(byte)Coordinates.Y] - destinationCoordinates[(byte)Coordinates.Y], 2)
                +
                Math.Pow(originCoordinates[(byte)Coordinates.Z] - destinationCoordinates[(byte)Coordinates.Z], 2)
            );
        }

        private decimal[] CalcuclateFlightDuration()
        {
            const decimal AUinKM = 149597870.7M;
            const decimal CinKM = 299792.458M;

            decimal distance = (decimal)CalcuclateFlightDistance();

            decimal flightDurationInSeconds = (distance * AUinKM) / (Spaceship.Speed * CinKM);
            decimal flightDurationInHours = flightDurationInSeconds / 3600;

            return new decimal[2] {
                Math.Floor(flightDurationInHours),
                Math.Round((flightDurationInHours - Math.Floor(flightDurationInHours)) * 60, 0)
            };
        }

        public string GetFlightDuration()
        {
            decimal[] flightTime = CalcuclateFlightDuration();
            return $"Flight time: {flightTime[(byte)Time.Hour]} Hour and {flightTime[(byte)Time.Minute]} minutes.";
        }

        private enum Coordinates
        {
            X, 
            Y, 
            Z
        }
        private enum Time
        {
            Hour,
            Minute
        }

        public FlightDTO GetDTO()
        {
            return new FlightDTO(Id, Departuretime, Status, FlightNumber, OriginGate.GetDTO(), DestinationGate.GetDTO(), new(Spaceship.Id, Spaceship.Name, Spaceship.Seat, Spaceship.Speed, Spaceship.Role));
        }

    }
}
