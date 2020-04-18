using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace Uber_project
{
    public partial class crystal_form : Form
    {
        CrystalReport2 cr2;
        CrystalReport1 cr1;
        CrystalReport3 cr3;

        public crystal_form()
        {
            InitializeComponent();
        }

        private void crystal_form_Load(object sender, EventArgs e)
        {
            cr2 = new CrystalReport2();
            cr1 = new CrystalReport1();
            cr3 = new CrystalReport3();
            foreach (ParameterDiscreteValue v in cr2.ParameterFields[1].DefaultValues)
                comboBox1.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr2.SetParameterValue(0, textBox1.Text);
            cr2.SetParameterValue(1, comboBox1.Text);

            crystalReportViewer1.ReportSource = cr2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr1;
        }
    }
}
