using BLL.Entity;

namespace LongdysseyWebApplication.Models.FlightModels
{
    public class FlightDetailViewModel
    {
        public Flight Flight;
        public List<long> AvailableSeats { get; private set; }
        public long BookFlightId { get; set; }
        public long SelectedSeat { get; set; }
        public FlightDetailViewModel(Flight flight, List<long> availableSeats)
        {
            Flight = flight;
            AvailableSeats = availableSeats;
        }

        public FlightDetailViewModel()
        {

        }
    }
}
