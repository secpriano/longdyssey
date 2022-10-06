using BLL.Container;
using BLL.Entity;
using DAL;
using System.Windows.Forms;
using Test.STUB;

namespace UIL
{
    public partial class FlightAdmin : Form
    {
        FlightContainer fc = new(new FlightDAL());
        SpaceportContainer sc = new(new SpaceportSTUB());
        public FlightAdmin()
        {
            InitializeComponent();
            
            List<string> spaceportsName = new List<string>();

            sc.GetAll().ForEach(spaceport => { spaceportsName.Add(spaceport.Name); });

            ComboBoxOriginSpaceport.DataSource = spaceportsName;
            ComboBoxDestinationSpaceport.DataSource = spaceportsName;
        }

        private void ButtonViewAll_Click(object sender, EventArgs e)
        {

        }

        private void ButtonViewOneById_Click(object sender, EventArgs e)
        {

        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
