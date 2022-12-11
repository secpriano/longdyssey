using BLL.Container;
using BLL.Entity;
using DAL;
using Test.STUB;

namespace UIL
{
    public partial class Dienstregeling : Form
    {
        private readonly AstronomicalObjectContainer AOc = new(new AstronomicalObjectDAL());
        public FlightLineScheduler FlightLineScheduler { get; set; }

        private readonly Graphics g;
        private readonly Pen orbit = new(Color.Blue, 3);
        private readonly Pen path = new(Color.Purple, 3);

        private readonly int formMidX, formMidY;

        private decimal zoom = 0;

        public Dienstregeling()
        {
            InitializeComponent();

            g = CreateGraphics();

            formMidX = Size.Width / 2;
            formMidY = Size.Height / 2;
        }

        private readonly List<decimal> Azimuths = new();
        private readonly List<decimal> Inclinations = new();

        private void VluchtZoeken_Load(object sender, EventArgs e)
        {
            SpaceshipContainer spaceshipContainer = new(new SpaceshipSTUB());
            comboBoxSpaceships.DataSource = spaceshipContainer.GetAll();
            comboBoxSpaceships.DisplayMember = "Name";

            // Zonnestelsel maken
            AOc.GetAll().ForEach(PointOfInterest =>
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

                Azimuths.Add(pointOfInterestX); 
                Inclinations.Add(pointOfInterestY);

                buttonPoint.Location = new Point((formMidX - buttonPoint.Width / 2) + pointOfInterestX, (formMidY - buttonPoint.Height / 2) + pointOfInterestY);
            });

            DrawCanvas();
        }

        private readonly List<Button> buttonPoints = new List<Button>();

        // Zoom of zoom uit van het zonnestelsel
        private void TrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(0, 0, 0));
            zoom = (decimal)trackBarZoom.Value / 10 + 1;
            for (int i = 0; i < buttonPoints.Count; i++)
            {
                decimal zoomX = Azimuths[i] * zoom;
                decimal zoomY = Inclinations[i] * zoom;

                buttonPoints[i].Location = new Point((int)(formMidX - buttonPoints[i].Width / 2 + zoomX), (int)(formMidY - buttonPoints[i].Height / 2 + zoomY));
            }
            DrawCanvas();
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

        public void DrawFlightRadius(AstronomicalObject departAO, decimal flightRadius)
        {
            foreach (Button button in buttonPoints)
            {
                if (button.Text == departAO.Name)
                {
                    int D = (int)(flightRadius * 15 * zoom);
                    int R = D / 2;

                    g.Clear(Color.FromArgb(0, 0, 0));
                    g.DrawEllipse(path, (button.Location.X + button.Width / 2) - R, (button.Location.Y + button.Height / 2) - R, D, D);
                    DrawCanvas();
                    break;
                }
            }
            Thread.Sleep(50);

        }

        private void ButtonGenerateSchedule_Click(object sender, EventArgs e)
        {
            FlightLineScheduler = new(this, (Spaceship)comboBoxSpaceships.SelectedItem, AOc.GetAll(), dateTimePickerStartDate.Value);
        }

        private void DrawCanvas()
        {
            DrawOrbit();
        }
    }
}
