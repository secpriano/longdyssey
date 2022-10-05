using IL.Interface.DAL;

namespace BLL.Container
{
    public class FlightContainer
    {
        IFlightDAL Data;

        public FlightContainer(IFlightDAL data)
        {
            Data = data;
        }
    }
}
