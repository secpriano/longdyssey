using BLL.Container;
using DAL;
using IL.DTO;
using IL.Interface.DAL;

namespace BLL.Entity
{
    public class Flight
    {
        public long Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public long Status { get; set; }
        public string FlightNumber { get; set; }
        public Gate OriginGate { get; set; }
        public Gate DestinationGate { get; set; }
        public Spaceship Spaceship { get; set; }
        public IBoardingpassDAL? BoardingpassDb { get; set; }

        public Flight(DateTime departuretime, long status, Gate originGate, Gate destinationGate, Spaceship spaceship)
        {
            DepartureTime = departuretime;
            Status = status;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;

            GenerateFlightNumber();

        }

        public Flight(FlightDTO dto)
        {
            Id = dto.Id;
            DepartureTime = dto.DepartureTime;
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

        private double CalculateFlightDistance()
        {
            double[] originCoordinates = OriginGate.Spaceport.AstronomicalObject.SphericalToCartesianCoordinates();

            double[] destinationCoordinates = DestinationGate.Spaceport.AstronomicalObject.SphericalToCartesianCoordinates();

            return Math.Sqrt(
                Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.X] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.X], 2)
                +
                Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.Y] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.Y], 2)
                +
                Math.Pow(originCoordinates[(byte)AstronomicalObject.Coordinates.Z] - destinationCoordinates[(byte)AstronomicalObject.Coordinates.Z], 2)
            );
        }

        private decimal[] CalculateFlightDuration()
        {
            const decimal AUinKM = 149597870.7M;
            const decimal CinKM = 299792.458M;

            decimal distance = (decimal)CalculateFlightDistance();

            decimal flightDurationInSeconds = (distance * AUinKM) / (Spaceship.Speed * CinKM);
            decimal flightDurationInHours = flightDurationInSeconds / 3600;

            return new decimal[2] {
                Math.Floor(flightDurationInHours),
                Math.Round((flightDurationInHours - Math.Floor(flightDurationInHours)) * 60, 0)
            };
        }

        public string GetFlightDuration()
        {
            decimal[] flightTime = CalculateFlightDuration();
            return $"{flightTime[(byte)Time.Hour]} Hours and {flightTime[(byte)Time.Minute]} minutes.";
        }
        public DateTime CalculateArrivalDateTime()
        {
            decimal[] flightTime = CalculateFlightDuration();
            TimeSpan flightDuration = new TimeSpan((int)flightTime[(byte)Time.Hour], (int)flightTime[(byte)Time.Minute], 0);
            return DepartureTime + flightDuration;
        }

        public bool BookFlight(long seat, long userId) => BoardingpassDb.BookFlight(seat, Id, userId);
        public List<Boardingpass> GetBookingByFlightId()
        {
            List<Boardingpass> boardingpasses = new();

            BoardingpassDb.GetBookingByFlightId(Id).ForEach(DTO =>
            {
                boardingpasses.Add(new(DTO));
            });

            return boardingpasses;
        }

        private enum Time
        {
            Hour,
            Minute
        }

        public FlightDTO GetDTO() => new(Id, DepartureTime, Status, FlightNumber, OriginGate.GetDTO(), DestinationGate.GetDTO(), Spaceship.GetDTO());
    }
}
