using BLL.Container;
using DAL;

namespace UIL
{
    public partial class VluchtZoeken : Form
    {
        FlightContainer fc = new(new FlightDAL());

        public VluchtZoeken()
        {
            InitializeComponent();

            fc.GetAll().ForEach(flight =>
            {
                Button flightLink = new()
                {
                    Text = $"{flight.DestinationGate.Spaceport.Name} | {flight.OriginGate.Spaceport.Name}",
                };
            });
        }
    }
}
