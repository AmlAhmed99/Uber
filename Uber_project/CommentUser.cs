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
    public partial class CommentUser : Form
    {
        string ordb = "Data Source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;

        public CommentUser()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {


            
        }
        void clear()
        {
            textBox1.Text = textBox3.Text = textBox4.Text = textBox5.Text =textBox2.Text ="";
        }
        private void button4_Click(object sender, EventArgs e)
        {

           

        }

        private void CommentUser_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            if (radioButton1.Checked == true)
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into COMMENT_TABLE(COMM_ID,RATING,ABOUT,TO_COMM,FROM_COMM) values (:COMM_ID,:RATING,:ABOUT,:TO_COMM,:FROM_COMM)";
                cmd.Parameters.Add("COMM_ID", textBox1.Text);
        
                cmd.Parameters.Add("RATING", comboBox1.SelectedItem.ToString());
                cmd.Parameters.Add("ABOUT", textBox5.Text);
                cmd.Parameters.Add("TO_COMM", textBox4.Text);
                cmd.Parameters.Add("FROM_COMM", textBox3.Text);
                try
                {
                    int r = cmd.ExecuteNonQuery();
                    if (r != -1)
                    {
                        comboBox1.Items.Add(comboBox1.Text);
                        MessageBox.Show("New Comment is added");
                        clear();
                    }
                }
                catch
                {
                    MessageBox.Show("New Comment is not added");
                }

            }

            else if (radioButton2.Checked == true)
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "update COMMENT_TABLE set RATING=:rate, ABOUT=:about , TO_COMM=:to_com , FROM_COMM=:from_com where COMM_ID =:id";

                c.Parameters.Add("rate", comboBox1.SelectedItem.ToString());
                c.Parameters.Add("about", textBox5.Text);
                c.Parameters.Add("to_com", textBox4.Text);
                c.Parameters.Add("from_com", textBox3.Text);
                c.Parameters.Add("id", textBox1.Text);
                try
                {
                    int r = c.ExecuteNonQuery();
                    if (r != -1)
                    {
                        MessageBox.Show("Your comment modified");
                        clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Your comment is not  modified check dp or add another one");
                }
            }



            else if (radioButton3.Checked == true)
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "Delete from COMMENT_TABLE where COMM_ID=:id";
                c.Parameters.Add("id", textBox1.Text);
                int r = c.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("your comment deleted");
                    comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";

                }
            }

            else
            {
                MessageBox.Show("Please choose your option or not deleted ,,no data in db");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            TripUser go = new TripUser();
            go.Show();
            this.Hide();
        }
    }
}
