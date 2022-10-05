using BLL.Container;
using DAL;
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
