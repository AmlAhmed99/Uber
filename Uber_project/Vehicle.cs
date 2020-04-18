using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Uber_project
{
    public partial class Vehicle : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Vehicle()
        {
            InitializeComponent();
        }
        void clear()
        {
            license_textbox.Text = model_textbox.Text = color_textbox.Text = type_textbox.Text =  "";
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                DataRow selectedrow = ds.Tables[0].Rows[row];

                selectedrow.Delete();
                adapter.Update(ds, ds.Tables[0].TableName);
                ds.AcceptChanges();
                MessageBox.Show("vehicles is deleted");
                clear();

            }
            catch {
                MessageBox.Show("vehicles is not deleted,,no data in DB plz add new vehicle first");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newrow = ds.Tables[0].NewRow();

                newrow["LICENSE_NUMDER"] = license_textbox.Text;
                newrow["model"] = Int32.Parse(model_textbox.Text);
                newrow["type"] = type_textbox.Text;
                newrow["color"] = color_textbox.Text;

                ds.Tables[0].Rows.Add(newrow);
                adapter.Update(ds, ds.Tables[0].TableName);
                ds.AcceptChanges();
                MessageBox.Show("New vehicle is added");
                clear();
            }
            catch {
                MessageBox.Show("New vehicle is not added");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.SelectedCells[0].RowIndex;
                DataRow updaterow = ds.Tables[0].Rows[row];

                updaterow.BeginEdit();

                updaterow["LICENSE_NUMDER"] = license_textbox.Text;
                updaterow["model"] = Int32.Parse(model_textbox.Text);
                updaterow["type"] = type_textbox.Text;
                updaterow["color"] = color_textbox.Text;

                updaterow.EndEdit();

                adapter.Update(ds, ds.Tables[0].TableName);
                ds.AcceptChanges();
                MessageBox.Show("selected vehicle is updated");
                clear();
            }
            catch {
                MessageBox.Show("selected vehicle is not updated");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[row];

            license_textbox.Text = selectedrow.Cells[0].Value.ToString();
            color_textbox.Text = selectedrow.Cells[1].Value.ToString();
            type_textbox.Text = selectedrow.Cells[2].Value.ToString();
            model_textbox.Text = selectedrow.Cells[3].Value.ToString();
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            string cmdstr = "select * from vehicle_table;";
            string connstr = "data source = orcl; user id = hr; password = hr";

            adapter = new OracleDataAdapter(cmdstr, connstr);
            builder = new OracleCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Vehicle_FormClosed(object sender, FormClosedEventArgs e)
        {
            adapter.Update(ds.Tables[0]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Option_admin od = new Option_admin();
            od.Show();
            this.Hide();
        }
    }
}
