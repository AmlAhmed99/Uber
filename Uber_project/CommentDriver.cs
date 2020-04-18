using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Uber_project
{
    public partial class CommentDriver : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
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
        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT_COMMENT_DRIVER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("comm_id", textBox1.Text);
            cmd.Parameters.Add("rating", textBox6.Text);
            cmd.Parameters.Add("about", textBox5.Text);
            cmd.Parameters.Add("to_comm", textBox4.Text);
            cmd.Parameters.Add("from_comm", textBox3.Text);
            cmd.Parameters.Add("driver_ssn", textBox2.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New comment is added");
                clear();
            }
            catch {
                MessageBox.Show("New comment isnot added,,tou should register now with ssn");
            }
        }

        private void CommentDriver_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SHOW_ALL_COMMENTS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("driver_ssn", textBox2.Text);
            cmd.Parameters.Add("about", OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0]);
                    //comboBox1.Items.Add(dr[0]);

                }
                dr.Close();
            }
            catch {
                MessageBox.Show("NO Data to view");
            }

        }
    }
}
