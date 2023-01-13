using Algorithm;
using BLL.Container;
using BLL.Entity;
using DAL;
using Test.STUB;

namespace UIL
{
    public partial class Dienstregeling : Form
    {
        private readonly AstronomicalObjectContainer AOc = new(new AstronomicalObjectDAL());
        public FlightScheduler FlightScheduler { get; set; }

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
            AOc.GetAll().ForEach(AO =>
            {
                Button buttonPoint = new()
                {
                    Text = AO.Name,
                    AutoSize = true
                };
                buttonPoints.Add(buttonPoint);
                Controls.Add(buttonPoint);

                int AOX = (int)(AO.SphericalToCartesianCoordinates(out _)[0] * 15);
                int AOY = (int)(AO.SphericalToCartesianCoordinates(out _)[1] * 15);

                Azimuths.Add(AOX); 
                Inclinations.Add(AOY);

                buttonPoint.Location = new Point((formMidX - buttonPoint.Width / 2) + AOX, (formMidY - buttonPoint.Height / 2) + AOY);
            });

            DrawCanvas();
        }

        private readonly List<Button> buttonPoints = new();

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

        public void DrawForm(AstronomicalObject departAO, decimal flightRadius, List<AstronomicalObject> tempAOs, List<AstronomicalObject> AOs)
        {
            g.Clear(Color.FromArgb(0, 0, 0));

            foreach (Button button in buttonPoints)
            {
                if (button.Text == departAO.Name)
                {
                    int D = (int)(flightRadius * 15 * 2 * zoom);
                    int R = D / 2;

                    g.Clear(Color.FromArgb(0, 0, 0));
                    g.DrawEllipse(path, (button.Location.X + button.Width / 2) - R, (button.Location.Y + button.Height / 2) - R, D, D);
                    DrawCanvas();
                    break;
                }
            }

            for (int i = 0; i < tempAOs.Count; i++)
            {
                int AOX = (int)(tempAOs[i].SphericalToCartesianCoordinates(out _)[0] * 15);
                int AOY = (int)(tempAOs[i].SphericalToCartesianCoordinates(out _)[1] * 15);
                buttonPoints[i].Location = new Point(formMidX - buttonPoints[i].Width / 2 + AOX, (formMidY - buttonPoints[i].Height / 2) + AOY);
            }

            Thread.Sleep(250);
        }

        private void ButtonGenerateSchedule_Click(object sender, EventArgs e)
        {
            //FlightScheduler = new(this, (Spaceship)comboBoxSpaceships.SelectedItem, AOc.GetAll(), dateTimePickerStartDate.Value);
        }

        private void DrawCanvas()
        {
            DrawOrbit();
        }
    }
}
