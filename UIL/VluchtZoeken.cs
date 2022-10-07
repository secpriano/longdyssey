using BLL.Container;
using BLL.Entity;
using DAL;
using System.Diagnostics.Metrics;
using Test.STUB;

namespace UIL
{
    public partial class VluchtZoeken : Form
    {
        FlightContainer fc = new(new FlightDAL());

        public VluchtZoeken()
        {
            InitializeComponent();

            dataGridViewFlight.DataSource = fc.GetAll();
        }
    }
}
