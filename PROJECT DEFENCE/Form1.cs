using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace PROJECT_DEFENCE
{
    public partial class Form1 : Form
    {
        mycon mc = new mycon();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Please enter your username & password!");
            }
            else
            {
                mc.connect();
                mc.cmd = new MySqlCommand("select * from tblogin where username = @username and password= @password", mc.con);

                mc.cmd.Parameters.Add(new MySqlParameter("username", textBox1.Text));
                mc.cmd.Parameters.Add(new MySqlParameter("password", textBox3.Text));
                mc.dr = mc.cmd.ExecuteReader();

                if (mc.dr.Read())
                {
                    MessageBox.Show("You have Successfully Login  !", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 fr2 = new Form2();
                    fr2.Show();
                    this.Hide();

                    //mf.Show();
                }

                else
                {
                    MessageBox.Show("Invalid Username or password", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mc.Disconnect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
