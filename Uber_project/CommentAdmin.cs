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
    public partial class CommentAdmin : Form
    {
        public CommentAdmin()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Option_admin od = new Option_admin();
            od.Show();
            this.Hide();
        }
    }
}
