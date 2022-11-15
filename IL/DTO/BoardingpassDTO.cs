namespace IL.DTO
{
    public class BoardingpassDTO
    {
        public FlightDTO Flight { get; set; }
        public UserDTO User { get; set; }
        public long Seat { get; set; }

        public BoardingpassDTO(FlightDTO flight, UserDTO user, long seat)
        {
            Flight = flight;
            User = user;
            Seat = seat;
        }
    }
}
