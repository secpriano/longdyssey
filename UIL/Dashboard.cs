using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIL
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ButtonVluchtZoeken_Click(object sender, EventArgs e)
        {
        }

        private void ButtonVluchtAdmin_Click(object sender, EventArgs e)
        {
            FlightAdmin flightAdmin = new();
            flightAdmin.ShowDialog();
        }

        private void ButtonSpaceshipAdmin_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSpaceportAdmin_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUserAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}
