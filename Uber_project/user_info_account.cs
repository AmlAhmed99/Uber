using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Uber_project
{
    public partial class user_info_account : UserControl
    {
        public user_info_account()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TripUser tu = new TripUser();
            tu.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TripUser tu = new TripUser();
            tu.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();
        }

        private void user_info_account_Load(object sender, EventArgs e)
        {

        }
    }
}
