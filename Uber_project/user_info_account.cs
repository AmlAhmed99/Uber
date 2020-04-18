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
    public partial class user_info_account : UserControl
    {
        string ordb = @"User Id=hr;Password=hr; Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = 
        (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))   (CONNECT_DATA = (SERVICE_NAME = orcl)))";
        OracleConnection conn;
        public user_info_account()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

           
        }
        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
        private void user_info_account_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("Please Enter Your Data ");
            else
            {
                try
                {
                    cmd.CommandText = "insert into USER_TABLE values (:FIRST_NAME,:LASR_NAME,:SSN,:MAIL,:GENDER,:PHONE)";
                    cmd.Parameters.Add("FIRST_NAME", textBox1.Text);
                    cmd.Parameters.Add("LASR_NAME", textBox5.Text);
                    cmd.Parameters.Add("SSN", textBox4.Text);
                    cmd.Parameters.Add("MAIL", textBox6.Text);
                    cmd.Parameters.Add("GENDER", textBox2.Text);
                    cmd.Parameters.Add("PHONE", textBox3.Text);
                    int r = cmd.ExecuteNonQuery();
                    if (r != -1) { MessageBox.Show("Registeration Is Successfully, Please Enter Your Data in a Login Panel "); }
                    clear();
                }
                catch (OracleException)
                {
                    MessageBox.Show("Please Enter Your Real Data !! ");
                    textBox4.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (textBox7.Text == "" || textBox8.Text == "")
                MessageBox.Show("Please Enter Your Data ");
            else
            {
                cmd.CommandText = "Select * from USER_TABLE";
                OracleDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[2].ToString() == textBox7.Text && rd[3].ToString() == textBox8.Text)
                    {
                        MessageBox.Show("Welcome Back *_*");

                        textBox7.Text = "";
                        textBox8.Text = "";

                        TripUser tu = new TripUser();
                        tu.Show();
                        this.Hide();
                        Form1 b = new Form1();
                        b.Hide();
                    }
                    

                }
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Your Data In a Login Panel *_* ");
        }
    }
}
