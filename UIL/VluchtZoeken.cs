using BLL.Container;
using BLL.Entity;
using DAL;

namespace UIL
{
    public partial class VluchtZoeken : Form
    {
        FlightContainer fc = new(new FlightDAL());
        PointOfInterestContainer pc = new(new PointOfInterestDAL());
        
        private readonly Graphics g;
        private readonly Pen orbit = new(Color.Blue, 3);
        private readonly Pen path = new(Color.Purple, 3);

        private readonly int formMidX, formMidY;

        public VluchtZoeken()
        {
            InitializeComponent();

            g = CreateGraphics();

            formMidX = Size.Width / 2;
            formMidY = Size.Height / 2;
        }

        private readonly List<decimal> pointOfInterestsX = new();
        private readonly List<decimal> pointOfInterestsY = new();

        private void VluchtZoeken_Load(object sender, EventArgs e)
        {
            // Zonnestelsel maken
            pc.GetAll().ForEach(PointOfInterest =>
            {
                Button buttonPoint = new()
                {
                    Text = PointOfInterest.Name,
                    AutoSize = true
                };
                buttonPoints.Add(buttonPoint);
                Controls.Add(buttonPoint);

                int pointOfInterestX = (int)(PointOfInterest.SphericalToCartesianCoordinates()[0] * 15);
                int pointOfInterestY = (int)(PointOfInterest.SphericalToCartesianCoordinates()[1] * 15);

                pointOfInterestsX.Add(pointOfInterestX); 
                pointOfInterestsY.Add(pointOfInterestY);

                buttonPoint.Location = new Point((formMidX - buttonPoint.Width / 2) + pointOfInterestX, (formMidY - buttonPoint.Height / 2) + pointOfInterestY);
            });

            int row = 75;

            // Vluchten laten zien
            fc.GetAll().ForEach(flight =>
            {
                Button flightLink = new()
                {
                    Text = $"From: {flight.OriginGate.Spaceport.PointOfInterest.Name} | To: {flight.DestinationGate.Spaceport.PointOfInterest.Name}\n" +
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
                flightLink.Location = new Point((Size.Width) - 400, row);
                row += 125;
            });

            DrawOrbit();
        }

        Flight selectedFlight;
        // Knop ingedrukt van een vlucht afhandelen
        public void FlightLink_Click(Flight flight)
        {
            selectedFlight = flight;
            DrawPath();
        }

        private readonly List<Button> buttonPoints = new List<Button>();

        // Zoom of zoom uit van het zonnestelsel
        private void TrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(0, 0, 0));
            decimal zoom = (decimal)trackBarZoom.Value / 10 + 1;
            for (int i = 0; i < buttonPoints.Count; i++)
            {
                decimal zoomX = pointOfInterestsX[i] * zoom;
                decimal zoomY = pointOfInterestsY[i] * zoom;

                buttonPoints[i].Location = new Point((int)(formMidX - buttonPoints[i].Width / 2 + zoomX), (int)(formMidY - buttonPoints[i].Height / 2 + zoomY));
            }
            DrawOrbit();
            if (selectedFlight != null)
            {
                DrawPath();
            }
        }

        // Maakt een pad van een gekozen vlucht
        Point point1 = new(), point2 = new();
        private void DrawPath()
        {
            buttonPoints.ForEach(bp =>
            {
                if (bp.Text == selectedFlight.OriginGate.Spaceport.PointOfInterest.Name)
                {
                    point1 = new Point(bp.Location.X + bp.Width / 2, bp.Location.Y + bp.Height / 2);
                }
                if (bp.Text == selectedFlight.DestinationGate.Spaceport.PointOfInterest.Name)
                {
                    point2 = new Point(bp.Location.X + bp.Width / 2, bp.Location.Y + bp.Height / 2);
                }
            });

            g.Clear(Color.FromArgb(0, 0, 0));
            DrawOrbit();
            g.DrawLine(path, point1, point2);
        }

        // Voeg de orbits van point of interest
        private void DrawOrbit()
        {
            foreach (Button button in buttonPoints)
            {
                int diameter = (int)Math.Sqrt(Math.Pow(button.Location.X + button.Width / 2 - formMidX, 2) + Math.Pow(button.Location.Y + button.Height / 2 - formMidY, 2)) * 2;
                int radius = diameter / 2;
                g.DrawEllipse(orbit, formMidX - radius, formMidY - radius, diameter, diameter);
            }
        }
    }
}
