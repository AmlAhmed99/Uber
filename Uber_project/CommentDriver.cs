using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uber_project
{
    public partial class CommentDriver : Form
    {
        public CommentDriver()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TripDriver t = new TripDriver();
            t.Show();
            this.Hide();
        }
    }
}
