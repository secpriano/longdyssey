using BLL.Container;
using BLL.Entity;
using DAL;
using System.Diagnostics.Metrics;
using Test.STUB;

namespace UIL
{
    public partial class FlightAdmin : Form
    {
        FlightContainer fc = new(new FlightDAL());
        SpaceportContainer spc = new(new SpaceportSTUB());
        SpaceshipContainer ssc = new(new SpaceshipSTUB());

        public FlightAdmin()
        {
            InitializeComponent();
            
            ComboBoxOriginSpaceport.DataSource = spc.GetAll();
            ComboBoxOriginSpaceport.DisplayMember = "Name";
            ComboBoxOriginSpaceport.ValueMember = "Id";
            ComboBoxDestinationSpaceport.DataSource = spc.GetAll();
            ComboBoxDestinationSpaceport.DisplayMember = "Name";
            ComboBoxDestinationSpaceport.ValueMember = "Id";

            ComboBoxSpaceship.DataSource = ssc.GetAll();
            ComboBoxSpaceship.DisplayMember = "Name";
            ComboBoxSpaceship.ValueMember = "Id";

            DateTimePickerVertrekDatum.Value = DateTime.Now;
        }

        private void ButtonViewAll_Click(object sender, EventArgs e)
        {
            dataGridViewFlight.DataSource = fc.GetAll();
        }

        private void ButtonViewOneById_Click(object sender, EventArgs e)
        {
            List<Flight> flights = new List<Flight>
            {
                fc.GetByID((long)numericUpDownID.Value)
            };
            dataGridViewFlight.DataSource = flights[0];
        }
        
        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            Flight flight = new(DateTimePickerVertrekDatum.Value, 1, "UITO", (Gate)ComboBoxOriginGate.SelectedItem, (Gate)ComboBoxDestinationGate.SelectedItem, (Spaceship)ComboBoxSpaceship.SelectedItem, null);
            fc.Add(flight);
            
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            fc.DeleteByID((long)numericUpDownID.Value);
        }

        private void ComboBoxOriginSpaceport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spaceport spaceport = (Spaceport)ComboBoxOriginSpaceport.SelectedItem;
            spaceport.GateDb = new GateSTUB();
            ComboBoxOriginGate.DataSource = spaceport.GetAllGates();
            ComboBoxOriginGate.DisplayMember = "Name";
            ComboBoxOriginGate.ValueMember = "Id";
        }

        private void ComboBoxDestinationSpaceport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spaceport spaceport = (Spaceport)ComboBoxDestinationSpaceport.SelectedItem;
            spaceport.GateDb = new GateSTUB();
            ComboBoxDestinationGate.DataSource = spaceport.GetAllGates();
            ComboBoxDestinationGate.DisplayMember = "Name";
            ComboBoxDestinationGate.ValueMember = "Id";
        }
    }
}
