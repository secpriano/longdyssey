namespace IL.DTO
{
    public class BoardingpassDTO
    {
        public long Id { get; set; }
        public FlightDTO Flight { get; }
        public UserDTO User { get; }
        public long Seat { get; }

        public BoardingpassDTO(long id, FlightDTO flight, UserDTO user, long seat)
        {
            Id = id;
            Flight = flight;
            User = user;
            Seat = seat;
        }
        
        public BoardingpassDTO(FlightDTO flight, UserDTO user, long seat)
        {
            Flight = flight;
            User = user;
            Seat = seat;
        }
    }
}
