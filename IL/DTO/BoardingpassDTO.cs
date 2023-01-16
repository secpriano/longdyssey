namespace IL.DTO
{
    public class BoardingpassDTO
    {
        public FlightDTO Flight { get; }
        public UserDTO User { get; }
        public long Seat { get; }

        public BoardingpassDTO(FlightDTO flight, UserDTO user, long seat)
        {
            Flight = flight;
            User = user;
            Seat = seat;
        }
    }
}
