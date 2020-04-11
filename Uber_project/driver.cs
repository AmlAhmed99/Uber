using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uber_project
{
    public partial class driver : UserControl
    {
        Form1 f = new Form1();
       
        public driver()
        {
            InitializeComponent();
        }

        private void driver_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TripDriver d = new TripDriver();
            d.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            TripDriver dd = new TripDriver();
          
            dd.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();





        }
    }
}
