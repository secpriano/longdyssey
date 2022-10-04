using IL.Interface;
using DAL;

namespace BLL.Container
{
    internal class FlightContainer
    {
        IFlight DA = new FlightDAL();
    }
}
