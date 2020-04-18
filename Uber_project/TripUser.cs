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
    public partial class TripUser : Form
    {
        string ordb = "Data Source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        public TripUser()
        {
            InitializeComponent();
        }
        void clear()
        {
            textBox1.Text  = textBox3.Text = textBox4.Text = textBox5.Text  =textBox5.Text= "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CommentUser cu = new CommentUser();
            cu.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           

        }

        private void TripUser_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into TRIP_TABLE (DRIVER_SSN,START_TIME,DURATION,COST,START_LOCATION,END_LOCATION,USER_SSN) values (:DRIVER_SSN,:START_TIME,:DURATION,:COST,:START_LOCATION,:END_LOCATION,:USER_SSN)";
            cmd.Parameters.Add("DRIVER_SSN", textBox1.Text);
            cmd.Parameters.Add("START_TIME", textBox5.Text);
            cmd.Parameters.Add("DURATION", textBox4.Text);
            cmd.Parameters.Add("COST", comboBox3.SelectedItem.ToString());
            cmd.Parameters.Add("START_LOCATION", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("END_LOCATION", comboBox2.SelectedItem.ToString());
            cmd.Parameters.Add("USER_SSN", textBox3.Text);
           
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {

                    MessageBox.Show("Your trip Has been booked");
                    clear();
                }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select * from TRIP_TABLE where COST=:cost";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("cost", comboBox4.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox5.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
                comboBox3.SelectedItem = dr[3].ToString();
                comboBox1.SelectedItem = dr[4].ToString();
                comboBox2.SelectedItem = dr[5].ToString();
                textBox3.Text = dr[6].ToString();
            }
            dr.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CommentUser cu = new CommentUser();
            cu.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            d.Show();
            this.Hide();
        }
    }
}
