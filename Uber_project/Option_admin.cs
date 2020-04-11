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
    public partial class Option_admin : UserControl
    {
        public Option_admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TripAdmin ta = new TripAdmin();
            ta.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommentDriver cd = new CommentDriver();
            cd.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vehiclee v = new Vehiclee();
            v.Show();
            this.Hide();
            Form1 b = new Form1();
            b.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
