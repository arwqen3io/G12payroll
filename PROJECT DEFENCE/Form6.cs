using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace PROJECT_DEFENCE
{
    public partial class Form6 : Form
    {
        String mycon = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";
        mycon mc = new mycon();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Visible = false;
            fr2.Visible = true;
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

        private void button11_Click(object sender, EventArgs e)
        {
           

            if (panel8.Visible)
            {
                panel8.Visible = false;
            }
            else
            {
                panel8.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {


            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Process proProcess = new Process();
                    proProcess.StartInfo.FileName = "cmd.exe";
                    proProcess.StartInfo.UseShellExecute = false;
                    proProcess.StartInfo.WorkingDirectory = @"C:\wamp\bin\mysql\mysql5.5.8\bin";
                    proProcess.StartInfo.RedirectStandardInput = true;
                    proProcess.StartInfo.RedirectStandardOutput = true;
                    proProcess.StartInfo.RedirectStandardError = true;
                    proProcess.Start();

                    StreamWriter myStreamWriter = proProcess.StandardInput;
                    StreamReader myStreamreader = proProcess.StandardOutput;
                    StreamReader myStreamerror = proProcess.StandardError;
                    myStreamWriter.WriteLine("MySqlDump -u root --database dbpayroll > \"" + folderBrowserDialog1.SelectedPath + "/PAYROLL" + DateTime.Now.ToString("MM-dd-yyyy hh-mm-ss") + ".sql" + "\"");
                    myStreamWriter.Close();
                    proProcess.WaitForExit();
                    proProcess.Close();
                    MessageBox.Show("Backup Success");
                    //loadproducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occure." + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains(".sql"))
                {
                    try
                    {
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Process prcProcess = new Process();
                            prcProcess.StartInfo.FileName = "cmd.exe";
                            prcProcess.StartInfo.UseShellExecute = false;
                            prcProcess.StartInfo.WorkingDirectory = @"C:\wamp\bin\mysql\mysql5.5.8\bin";
                            prcProcess.StartInfo.RedirectStandardInput = true;
                            prcProcess.StartInfo.RedirectStandardOutput = true;
                            prcProcess.Start();

                            StreamWriter myStreamWriter = prcProcess.StandardInput;
                            StreamReader mystreamreader = prcProcess.StandardOutput;
                            myStreamWriter.WriteLine("mysql -u root < \"" + openFileDialog1.FileName + "\"");

                            myStreamWriter.Close();
                            prcProcess.WaitForExit();
                            prcProcess.Close();
                            MessageBox.Show("Restored");
                            //loadproducts();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unexpected error occured. " + ex.Message);
                    }
                }
            }

            else
            {
                Console.WriteLine("This is not a valid database file. Please select the database file you want to restore.");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Visible = false;
            fr5.Visible = true;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            panel8.Visible = false;
            loadrecord();
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
                                string query = "INSERT INTO tbemp (empid, fname, bday, cont, jbtitle, dhire, empstatus, SSS, `PAG-IBIG`, PHILHEALTH, hourly) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10, @val11)";
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

            private void DeleteData(string tableName)
             {
                string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM " + tableName;

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            private void DeleteDatawk(string tableName)
            {
                string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM " + tableName;

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            private void DeleteDatapt(string tableName)
            {
                string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM " + tableName;

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            private void DeleteDataEmpt(string tableName)
            {
                string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM " + tableName;

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



            private void DeleteDataALL(string tableName)
            {
                string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM " + tableName;

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data deleted successfully from " + tableName + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete all data from the table?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                string tableName = "tbmonthly";

                if (result == DialogResult.Yes)
                {
                    DeleteData(tableName);
                }
                
            }

            private void checkBox5_CheckedChanged(object sender, EventArgs e)
            {
                List<string> tableNames = new List<string> { "tbmonthly", "tbparttime", "tbcontractual", "tbemp" }; // Replace with your desired table names

                DialogResult result = MessageBox.Show("Are you sure you want to delete all data from the tables?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (string tableName in tableNames)
                    {
                        DeleteData(tableName);
                    }
                }
            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete all data from the table?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                string tableName = "tbcontractual";

                if (result == DialogResult.Yes)
                {
                    DeleteData(tableName);
                }
            }

            private void checkBox3_CheckedChanged(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete all data from the table?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                string tableName = "tbparttime";

                if (result == DialogResult.Yes)
                {
                    DeleteData(tableName);
                }
            }

            private void checkBox4_CheckedChanged(object sender, EventArgs e)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete all data from the table?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                string tableName = "tbemp";

                if (result == DialogResult.Yes)
                {
                    DeleteData(tableName);
                }
            }

           private void loadrecord()
            {
                try
                {
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);

                    String Query = "select * from tbrecord;";

                    MySqlConnection MyConn = new MySqlConnection(mycon);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;
                    dataGridView1.Columns[0].HeaderText = "Transaction ID";
                    dataGridView1.Columns[1].HeaderText = "Employee Name";
                    dataGridView1.Columns[2].HeaderText = "Employee ID";
                    dataGridView1.Columns[3].HeaderText = "Date created";
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
            private void button1_Click_1(object sender, EventArgs e)
            {
                loadrecord();
            }

        }
    }

