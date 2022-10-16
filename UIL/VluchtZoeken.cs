using BLL.Container;
using BLL.Entity;
using DAL;

namespace UIL
{
    public partial class VluchtZoeken : Form
    {
        FlightContainer fc = new(new FlightDAL());

        public VluchtZoeken()
        {
            InitializeComponent();

            int row = 100;

            fc.GetAll().ForEach(flight =>
            {
                Button flightLink = new()
                {
                    Text = $"From: {flight.OriginGate.Spaceport.pointOfInterest.Name} | To: {flight.DestinationGate.Spaceport.pointOfInterest.Name}\n" +
                    $"From spaceport: {flight.OriginGate.Spaceport.Name} | To spaceport: {flight.DestinationGate.Spaceport.Name}\n" +
                    $"Departure gate: {flight.OriginGate.Name} | Arrival gate: {flight.DestinationGate.Name}\n\n" +
                    $"Spaceship: {flight.Spaceship.Name}\n" + 
                    flight.GetFlightDuration(),
                    AutoSize = true
                };

                flightLink.Click += (sender, args) =>
                {
                    FlightLink_Click(flight);
                };

                Controls.Add(flightLink);
                flightLink.Location = new Point((Size.Width / 2) - (flightLink.Size.Width / 2), row);
                row += 50;
            });
        }

        public void FlightLink_Click(Flight flight)
        {
        }
    }
}
