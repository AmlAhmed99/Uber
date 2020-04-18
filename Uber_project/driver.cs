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
    public partial class driver : UserControl
    {
        string ordb = @"User Id=hr;Password=hr; Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = 
        (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))   (CONNECT_DATA = (SERVICE_NAME = orcl)))";
        OracleConnection conn;
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
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("Please Enter Your Data ");
            else
            {
                try
                {
                    c.CommandText = "INSERT_DRIVER";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("fn", textBox1.Text);
                    c.Parameters.Add("ln", textBox5.Text);
                    c.Parameters.Add("ssn", textBox4.Text);
                    c.Parameters.Add("gndr", textBox2.Text);
                    c.Parameters.Add("mail", textBox6.Text);
                    c.Parameters.Add("phne", textBox3.Text);
                    c.Parameters.Add("vehicle_no", textBox9.Text);
                    c.ExecuteNonQuery();
                    MessageBox.Show("Registeration Is Successfully, Please Enter Your Data in a Login Panel");
                    clear();
                }
                catch (OracleException)
                {
                    MessageBox.Show("Please Enter Your Real Data !! ");
                    textBox4.Text = "";
                }
            }
            void clear()
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text =textBox8.Text= "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (textBox7.Text == "" || textBox8.Text == "")
                MessageBox.Show("Please Enter Your Data ");
            else
            {
                cmd.CommandText = "Select * from DRIVER_TABLE";
                OracleDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[2].ToString() == textBox7.Text && rd[4].ToString() == textBox8.Text)
                    {
                        MessageBox.Show("Welcome Back *_*");
                        textBox7.Text = "";
                        textBox8.Text = "";
                        TripDriver dd = new TripDriver();
                        dd.Show();
                        this.Hide();
                        Form1 b = new Form1();
                        b.Hide();
                    }
                }

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Your Data In a Login Panel *_* ");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
