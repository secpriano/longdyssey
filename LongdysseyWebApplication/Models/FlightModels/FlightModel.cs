using BLL.Entity;

namespace LongdysseyWebApplication.Models
{
    public class FlightModel
    {
        public long Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public long Status { get; set; }
        public string FlightNumber { get; set; }
        public Gate OriginGate { get; set; }
        public Gate DestinationGate { get; set; }
        public Spaceship Spaceship { get; set; }
        public FlightSchedule? FlightSchedule { get; set; }

        public FlightModel(long id, DateTime departureTime, long status, string flightNumber, Gate originGate, Gate destinationGate, Spaceship spaceship, FlightSchedule? flightSchedule)
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
        private double CalculateFlightDistance()
        {
            OriginGate.Spaceport.AstronomicalObject.SphericalToCartesianCoordinates(out double[] originCoordinates);

            DestinationGate.Spaceport.AstronomicalObject.SphericalToCartesianCoordinates(out double[] destinationCoordinates);

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
            TimeSpan flightDuration = new((int)flightTime[(byte)Time.Hour], (int)flightTime[(byte)Time.Minute], 0);
            return DepartureTime + flightDuration;
        }

        private enum Time
        {
            Hour,
            Minute
        }
    }
}
