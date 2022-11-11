using BLL.Entity;

namespace LongdysseyWebApplication.Models.FlightModels
{
    public class FlightDetailViewModel
    {
        public Flight Flight;
        public long BookFlightId { get; set; }
        public FlightDetailViewModel(Flight flight)
        {
            Flight = flight;    
        }
    }
}
