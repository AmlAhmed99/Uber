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
    public partial class TripDriver : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public TripDriver()
        {
            InitializeComponent();
        }

        private void trip_driver1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT_TRIP_DRIVER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("driver_ssn", textBox1.Text);
            cmd.Parameters.Add("start_time", textBox2.Text);
            cmd.Parameters.Add("duration", textBox5.Text);
            cmd.Parameters.Add("cost", textBox6.Text);
            cmd.Parameters.Add("start_location", textBox4.Text);
            cmd.Parameters.Add("end_location", textBox3.Text);
            cmd.Parameters.Add("USER_SSN", textBox8.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New trip is added");
                clear();
            }
            catch {
                MessageBox.Show("no trip is added,chech ssn driver and login first");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommentDriver cd = new CommentDriver();
            cd.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int max, neww;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SHOW_DETAILS";
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("cost", OracleDbType.Int32, ParameterDirection.Output);
            
            cmd.ExecuteNonQuery();
            try
            {
                max = Convert.ToInt32(cmd.Parameters["cost"].Value.ToString());
                neww = max;
                textBox7.Text = neww.ToString() ;

               
            }
            catch { neww = 1; }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE_TRIP_DRIVER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("driver_ssn", textBox1.Text);
            cmd.Parameters.Add("start_time", textBox2.Text);
            cmd.Parameters.Add("duration", textBox5.Text);
            cmd.Parameters.Add("cost", textBox6.Text);
            cmd.Parameters.Add("start_location", textBox4.Text);
            cmd.Parameters.Add("end_location", textBox3.Text);
            cmd.Parameters.Add("USER_SSN", textBox8.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New trip is updated");
                clear();
            }
            catch {
                MessageBox.Show("no trip is updated,,no data in database");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE_TRIP_DRIVER";
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.Parameters.Add("start_time", textBox2.Text);
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox8.Text = " ";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New trip is deleted");
                conn.Dispose();
            }
            catch {
                MessageBox.Show("no trip is deleted,,no data in database");
            }
        }
        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
        private void TripDriver_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
