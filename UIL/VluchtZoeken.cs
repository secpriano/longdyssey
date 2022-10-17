using BLL.Container;
using BLL.Entity;
using DAL;
using System.Drawing;

namespace UIL
{
    public partial class VluchtZoeken : Form
    {
        FlightContainer fc = new(new FlightDAL());
        PointOfInterestContainer pc = new(new PointOfInterestDAL());

        public VluchtZoeken()
        {
            InitializeComponent();

            int row = 25;

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

        private readonly List<decimal> X = new();
        private readonly List<decimal> Y = new();

        private void VluchtZoeken_Load(object sender, EventArgs e)
        {
            Brush blackBrush = (Brush)Brushes.Black;
            Graphics g = CreateGraphics();


            pc.GetAll().ForEach(PointOfInterest =>
            {
                Button buttonPoint = new()
                {
                    Text = PointOfInterest.Name,
                    AutoSize = true
                };
                buttonPoints.Add(buttonPoint);
                Controls.Add(buttonPoint);

                int originPointX = (int)(PointOfInterest.SphericalToCartesianCoordinates()[0] * 35);
                int originPointY = (int)(PointOfInterest.SphericalToCartesianCoordinates()[1] * 35);

                X.Add(originPointX); 
                Y.Add(originPointY);

                buttonPoint.Location = new Point((Size.Width / 2) + originPointX, (Size.Height / 2) + originPointY);
                                
                //g.FillRectangle(blackBrush, (X, y, 3, 3);
            });
        }
        public void FlightLink_Click(Flight flight)
        {   
        }

        private readonly List<Button> buttonPoints = new List<Button>();

        private void TrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            decimal zoom = (decimal)trackBarZoom.Value / 10 + 1;
            for (int i = 0; i < buttonPoints.Count; i++)
            {
                decimal zoomX = X[i] * zoom;
                decimal zoomY = Y[i] * zoom;

                buttonPoints[i].Location = new Point((int)(Size.Width / 2 + zoomX), (int)(Size.Height / 2 + zoomY));
            }
        }
    }
}
