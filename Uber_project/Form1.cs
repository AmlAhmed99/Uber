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
    public partial class Form1 : Form
    {
        public void addcontroltopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(c);
        }
        bool iscollapse;
        int panelwidth;
        public Form1()
        {
            InitializeComponent();
          //  timertime.Start();
            panelwidth = panel_left.Width;
            iscollapse = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("please enter user name and password");

            }
            else
            {

                if (textBox1.Text.Trim() == "admin" && textBox2.Text.Trim() == "aml")
                {
                    MessageBox.Show("you are successfuly login");
                    Option_admin a = new Option_admin();
                    addcontroltopanel(a);
                    a.Show();
                    
                    


                }
               else if (textBox1.Text.Trim() == "driver" && textBox2.Text.Trim() == "aml")
                {
                    MessageBox.Show("you are successfuly login");
                    driver d = new driver();
                    addcontroltopanel(d);
                    d.Show();
                    
                    


                }

                else
                {

                    MessageBox.Show("username or password incorrect");

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iscollapse)
            {
                panel_left.Width = panel_left.Width + 50;
                if (panel_left.Width >= panelwidth)
                {
                   
                    timer1.Stop();
                    iscollapse = false;
                   
                    this.Refresh();
                    

                }
            }
            else
            {
                panel_left.Width = panel_left.Width - 50;
                if (panel_left.Width <= 64)
                {
                    
                    timer1.Stop();
                    iscollapse = true;
                    
                    this.Refresh();
                    

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_left_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            user_info_account user = new user_info_account();
            addcontroltopanel(user);
            user.Show();
            
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            home h = new home();
            addcontroltopanel(h);
            h.Show();
            
        }

        private void btndelv_Click(object sender, EventArgs e)
        {
            vehicles_show v = new vehicles_show();
            addcontroltopanel(v);
            v.Show();
        }

        private void btnfeed_Click(object sender, EventArgs e)
        {
            Feedback_show ff = new Feedback_show();
            addcontroltopanel(ff);
            ff.Show();
        }
    }
}
