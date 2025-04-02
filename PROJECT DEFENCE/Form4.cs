using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.OleDb;

namespace PROJECT_DEFENCE
{
    public partial class Form4 : Form
    {
        String mycon = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";
        mycon mc = new mycon();
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Visible = false;
            fr6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Visible = false;
            fr5.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Visible = false;
            fr4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Visible = false;
            fr3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Visible = false;
            fr2.Visible = true;
        }

       
        
        private void loadpeople()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                String Query = "SELECT * FROM tbemp WHERE empstatus = 'Regular'";

                MySqlConnection MyConn = new MySqlConnection(mycon);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].HeaderText = "Employee ID";
                dataGridView1.Columns[1].HeaderText = "Full Name";
                dataGridView1.Columns[2].HeaderText = "Birthday";
                dataGridView1.Columns[3].HeaderText = "Contact Number";
                dataGridView1.Columns[4].HeaderText = "Job title";
                dataGridView1.Columns[5].HeaderText = "Date of hire";
                dataGridView1.Columns[6].HeaderText = "Employee Status";
                dataGridView1.Columns[10].HeaderText = "Hourly Rate";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void button7_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                try
                {

                    String Query = "UPDATE tbemp SET fname = '" + this.B2.Text + "', jbtitle = '" + this.B3.Text + "', empstatus = '" + this.B4.Text + "', cont = '" + this.B5.Text + "', SSS = '" + this.B6.Text + "', `PAG-IBIG` = '" + this.B7.Text + "', PHILHEALTH = '" + this.B8.Text + "', hourly = '" + this.B10.Text + "' WHERE empid = '" + B1.Text + "';";

                    MySqlConnection Myconn = new MySqlConnection(mycon);
                    MySqlCommand MyCommand = new MySqlCommand(Query, Myconn);
                    MySqlDataReader MyReader2;
                    Myconn.Open();
                    MyReader2 = MyCommand.ExecuteReader();
                    MessageBox.Show("Employee Info Has Been Updated");
                    

                    Myconn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No changes were made.");    
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show(" Nothing Change");
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
                {
                    cell = selectedCell;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    B1.Text = row.Cells["empid"].Value.ToString();
                    B2.Text = row.Cells["fname"].Value.ToString();
                    B3.Text = row.Cells["jbtitle"].Value.ToString();
                    B4.Text = row.Cells["empstatus"].Value.ToString();
                    B5.Text = row.Cells["cont"].Value.ToString();
                    B6.Text = row.Cells["SSS"].Value.ToString();
                    B7.Text = row.Cells["PAG-IBIG"].Value.ToString();
                    B8.Text = row.Cells["PHILHEALTH"].Value.ToString(); 
                    B9.Text = row.Cells["dhire"].Value.ToString();
                    B10.Text = row.Cells["hourly"].Value.ToString(); 
                   

                }
        }

      
       

      

    
                
            private void loadpeoplewk()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                String Query = "SELECT * FROM tbemp WHERE empstatus = 'Contractual'";

                MySqlConnection MyConn = new MySqlConnection(mycon);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].HeaderText = "Employee ID";
                dataGridView1.Columns[1].HeaderText = "Full Name";
                dataGridView1.Columns[2].HeaderText = "Birthday";
                dataGridView1.Columns[3].HeaderText = "Contact Number";
                dataGridView1.Columns[4].HeaderText = "Job title";
                dataGridView1.Columns[5].HeaderText = "Date of hire";
                dataGridView1.Columns[6].HeaderText = "Employee Status";
                dataGridView1.Columns[10].HeaderText = "Hourly Rate";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         

            private void loadpeoplept()
            {
                try
                {
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                    String Query = "SELECT * FROM tbemp WHERE empstatus = 'Part time'";

                    MySqlConnection MyConn = new MySqlConnection(mycon);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;
                    dataGridView1.Columns[0].HeaderText = "Employee ID";
                    dataGridView1.Columns[1].HeaderText = "Full Name";
                    dataGridView1.Columns[2].HeaderText = "Birthday";
                    dataGridView1.Columns[3].HeaderText = "Contact Number";
                    dataGridView1.Columns[4].HeaderText = "Job title";
                    dataGridView1.Columns[5].HeaderText = "Date of hire";
                    dataGridView1.Columns[6].HeaderText = "Employee Status";
                    dataGridView1.Columns[10].HeaderText = "Hourly Rate";
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

          
            private void pictureBox2_Click(object sender, EventArgs e)
            {
                Form5 fr5 = new Form5();
                this.Visible = false;
                fr5.Visible = true;
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                Form3 fr3 = new Form3();
                this.Visible = false;
                fr3.Visible = true;
            }

            private void button1_Click_1(object sender, EventArgs e)
            {
                loadpeople();
                textBox2.Clear();
                B1.Clear();
                B2.Clear();
                B3.SelectedIndex = -1;
                B4.SelectedIndex = -1;
                B5.Clear();
                B6.Clear();
                B7.Clear();
                B8.Clear();
                B9.Clear();
                B10.Clear();
            }

            private void button2_Click_1(object sender, EventArgs e)
            {
                loadpeoplewk();
                textBox2.Clear();
                B1.Clear();
                B2.Clear();
                B3.SelectedIndex = -1;
                B4.SelectedIndex = -1;
                B5.Clear();
                B6.Clear();
                B7.Clear();
                B8.Clear();
                B9.Clear();
                B10.Clear();
            }

            private void button3_Click_1(object sender, EventArgs e)
            {
                loadpeoplept();
                textBox2.Clear();
                B1.Clear();
                B2.Clear();
                B3.SelectedIndex = -1;
                B4.SelectedIndex = -1;
                B5.Clear();
                B6.Clear();
                B7.Clear();
                B8.Clear();
                B9.Clear();
                B10.Clear();

           
            }


            private void textBox2_TextChanged_1(object sender, EventArgs e)
            {
                 try
                {
                    String str = comboBox2.SelectedItem.ToString();
                    String Query = "";



                    if (str.Equals("Fullname"))
                    {
                        str = "fname";
                    }
                    else if (str.Equals("Job Title"))
                    {
                        str = "jbtitle";
                    }
                    else
                    {
                        str = "dhire";
                    }
                    Query = "select * from tbemp where " + str + " like '" + "%" + textBox2.Text + "%" + "';";
                    MySqlConnection MyConn = new MySqlConnection(mycon);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand;
                    DataTable dtable = new DataTable();
                    MyAdapter.Fill(dtable);
                    dataGridView1.DataSource = dtable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select category and type the keyword you want to search");
                }
            }

            private void button4_Click_1(object sender, EventArgs e)
            {
                if (panel5.Visible)
                {
                    panel5.Visible = false;
                }
                else
                {
                    panel5.Visible = true;
                }
            }

            

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }


         
      }    
}

       
       
    
