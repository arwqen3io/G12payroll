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
    public partial class Form5 : Form
    {
        String mycon = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";
        mycon mc = new mycon();
        public Form5()
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

       

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Connect to MySQL database
                //string connectionString = "server=localhost;database=dbexam;uid=root;pwd=your_password;";
                string connectionString = "datasource = localhost;Database=dbpayroll;username=root;convert zero datetime=true";
                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                {
                    connection.Open();

                    // Read data from Excel file
                    string connectionStringExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
                    OleDbConnection excelConnection = new OleDbConnection(connectionStringExcel);

                    excelConnection.Open();
                    DataTable dataTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dataTable != null)
                    {
                        string sheetName = dataTable.Rows[0]["TABLE_NAME"].ToString();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConnection);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            // Import data into MySQL table
                            while (reader.Read())
                            {
                                string query = "INSERT INTO tbcontractual (ID, Name, Monday, Tuesday, Wednesday, Thursday, Friday, hoursworked) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";
                                MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                                sqlCommand.Parameters.AddWithValue("@val1", reader[0].ToString());
                                sqlCommand.Parameters.AddWithValue("@val2", reader[1].ToString());
                                sqlCommand.Parameters.AddWithValue("@val3", reader[2].ToString());
                                sqlCommand.Parameters.AddWithValue("@val4", reader[3].ToString());
                                sqlCommand.Parameters.AddWithValue("@val5", reader[4].ToString());
                                sqlCommand.Parameters.AddWithValue("@val6", reader[5].ToString());
                                sqlCommand.Parameters.AddWithValue("@val7", reader[6].ToString());
                                sqlCommand.Parameters.AddWithValue("@val8", reader[7].ToString());

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Connect to MySQL database
                //string connectionString = "server=localhost;database=dbexam;uid=root;pwd=your_password;";
                string connectionString = "datasource = localhost;Database=dbpayroll;username=root;convert zero datetime=true";
                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                {
                    connection.Open();

                    // Read data from Excel file
                    string connectionStringExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
                    OleDbConnection excelConnection = new OleDbConnection(connectionStringExcel);

                    excelConnection.Open();
                    DataTable dataTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dataTable != null)
                    {
                        string sheetName = dataTable.Rows[0]["TABLE_NAME"].ToString();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConnection);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            // Import data into MySQL table
                            while (reader.Read())
                            {
                                string query = "INSERT INTO tbmonthly (ID, Name, Day1, Day2, Day3, Day4, Day5, Day6, Day7, Day8, Day9, Day10, Day11, Day12, Day13, Day14, Day15, Day16, Day17, Day18, Day19, Day20, Day21, hoursworked, daypresent) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10, @val11, @val12, @val13, @val14, @val15, @val16, @val17, @val18, @val19, @val20, @val21, @val22, @val23, @val24, @val25)";
                                MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                                sqlCommand.Parameters.AddWithValue("@val1", reader[0].ToString());
                                sqlCommand.Parameters.AddWithValue("@val2", reader[1].ToString());
                                sqlCommand.Parameters.AddWithValue("@val3", reader[2].ToString());
                                sqlCommand.Parameters.AddWithValue("@val4", reader[3].ToString());
                                sqlCommand.Parameters.AddWithValue("@val5", reader[4].ToString());
                                sqlCommand.Parameters.AddWithValue("@val6", reader[5].ToString());
                                sqlCommand.Parameters.AddWithValue("@val7", reader[6].ToString());
                                sqlCommand.Parameters.AddWithValue("@val8", reader[7].ToString());
                                sqlCommand.Parameters.AddWithValue("@val9", reader[8].ToString());
                                sqlCommand.Parameters.AddWithValue("@val10", reader[9].ToString());
                                sqlCommand.Parameters.AddWithValue("@val11", reader[10].ToString());
                                sqlCommand.Parameters.AddWithValue("@val12", reader[11].ToString());
                                sqlCommand.Parameters.AddWithValue("@val13", reader[12].ToString());
                                sqlCommand.Parameters.AddWithValue("@val14", reader[13].ToString());
                                sqlCommand.Parameters.AddWithValue("@val15", reader[14].ToString());
                                sqlCommand.Parameters.AddWithValue("@val16", reader[15].ToString());
                                sqlCommand.Parameters.AddWithValue("@val17", reader[16].ToString());
                                sqlCommand.Parameters.AddWithValue("@val18", reader[17].ToString());
                                sqlCommand.Parameters.AddWithValue("@val19", reader[18].ToString());
                                sqlCommand.Parameters.AddWithValue("@val20", reader[19].ToString());
                                sqlCommand.Parameters.AddWithValue("@val21", reader[20].ToString());
                                sqlCommand.Parameters.AddWithValue("@val22", reader[21].ToString());
                                sqlCommand.Parameters.AddWithValue("@val23", reader[22].ToString());
                                sqlCommand.Parameters.AddWithValue("@val24", reader[23].ToString());
                                sqlCommand.Parameters.AddWithValue("@val25", reader[24].ToString());

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Connect to MySQL database
                //string connectionString = "server=localhost;database=dbexam;uid=root;pwd=your_password;";
                string connectionString = "datasource = localhost;Database=dbpayroll;username=root;convert zero datetime=true";
                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                {
                    connection.Open();

                    // Read data from Excel file
                    string connectionStringExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
                    OleDbConnection excelConnection = new OleDbConnection(connectionStringExcel);

                    excelConnection.Open();
                    DataTable dataTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dataTable != null)
                    {
                        string sheetName = dataTable.Rows[0]["TABLE_NAME"].ToString();
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConnection);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            // Import data into MySQL table
                            while (reader.Read())
                            {
                                string query = "INSERT INTO tbparttime (ID, Name, TimeIn, Timeout, hoursworked) VALUES (@val1, @val2, @val3, @val4, @val5)";
                                MySqlCommand sqlCommand = new MySqlCommand(query, connection);

                                sqlCommand.Parameters.AddWithValue("@val1", reader[0].ToString());
                                sqlCommand.Parameters.AddWithValue("@val2", reader[1].ToString());
                                sqlCommand.Parameters.AddWithValue("@val3", reader[2].ToString());
                                sqlCommand.Parameters.AddWithValue("@val4", reader[3].ToString());
                                sqlCommand.Parameters.AddWithValue("@val5", reader[4].ToString());
                                
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Visible = false;
            fr6.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Visible = false;
            fr4.Visible = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadmonthly()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                String Query = "select * from tbmonthly;";
               
                MySqlConnection MyConn = new MySqlConnection(mycon);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].HeaderText = "Attendance ID";
                dataGridView1.Columns[1].HeaderText = "Full Name";
                dataGridView1.Columns[2].HeaderText = "Day 1";
                dataGridView1.Columns[3].HeaderText = "Day 2";
                dataGridView1.Columns[4].HeaderText = "Day 3";
                dataGridView1.Columns[5].HeaderText = "Day 4";
                dataGridView1.Columns[6].HeaderText = "Day 5";
                dataGridView1.Columns[7].HeaderText = "Day 6";
                dataGridView1.Columns[8].HeaderText = "Day 7";
                dataGridView1.Columns[9].HeaderText = "Day 8";
                dataGridView1.Columns[10].HeaderText = "Day 9";
                dataGridView1.Columns[11].HeaderText = "Day 10";
                dataGridView1.Columns[12].HeaderText = "Day 11";
                dataGridView1.Columns[13].HeaderText = "Day 12";
                dataGridView1.Columns[14].HeaderText = "Day 13";
                dataGridView1.Columns[15].HeaderText = "Day 14";
                dataGridView1.Columns[16].HeaderText = "Day 15";
                dataGridView1.Columns[17].HeaderText = "Day 16";
                dataGridView1.Columns[18].HeaderText = "Day 17";
                dataGridView1.Columns[19].HeaderText = "Day 18";
                dataGridView1.Columns[20].HeaderText = "Day 19";
                dataGridView1.Columns[21].HeaderText = "Day 20";
                dataGridView1.Columns[22].HeaderText = "Day 21";
                dataGridView1.Columns[23].HeaderText = "Total hours worked";
                dataGridView1.Columns[24].HeaderText = "Total Days Present";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadweekly()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                String Query = "select * from tbcontractual;";

                MySqlConnection MyConn = new MySqlConnection(mycon);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].HeaderText = "Attendance ID";
                dataGridView1.Columns[1].HeaderText = "Full Name";
                dataGridView1.Columns[2].HeaderText = "Monday";
                dataGridView1.Columns[3].HeaderText = "Tuesday";
                dataGridView1.Columns[4].HeaderText = "Wednesday";
                dataGridView1.Columns[5].HeaderText = "Thursday";
                dataGridView1.Columns[6].HeaderText = "Friday";
                dataGridView1.Columns[7].HeaderText = "Total Hours worked";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loaddaily()
        {
            try
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                String Query = "select * from tbparttime;";

                MySqlConnection MyConn = new MySqlConnection(mycon);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].HeaderText = "Attendance ID";
                dataGridView1.Columns[1].HeaderText = "Full Name";
                dataGridView1.Columns[2].HeaderText = "Time In";
                dataGridView1.Columns[3].HeaderText = "Time out";
                dataGridView1.Columns[4].HeaderText = "Total Hours worked";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadmonthly();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            loadweekly();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            loaddaily();
        }
      


        
            }
        }
    

