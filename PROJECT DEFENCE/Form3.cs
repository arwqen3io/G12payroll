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
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace PROJECT_DEFENCE
{
    public partial class Form3 : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        String mycon = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";
        public Form3()
        {
            InitializeComponent();
            button2.Click += button2_Click;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
          


           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Visible = false;
            fr2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Visible = false;
            fr4.Visible = true;
        }


        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                String str = comboBox1.SelectedItem.ToString();
                if (str.Equals("Regular"))
                {
                    loadpeople();
                }
                else if (str.Equals("Contractual"))
                {
                    loadpeoplewk();
                }
                else
                {
                    loadpeoplept();
                }

                panel4.Visible = false;
                panel6.Visible = true;
                panel8.Visible = true;
                panel2.Visible = true;

               
               

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

     
        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            dataGridView1.DataSource = null;

            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;



        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
                
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            
            panel2.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;





          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtResult.Text = "";
            DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
                {
                    cell = selectedCell;
                }

                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    EMPTX.Text = row.Cells["empid"].Value.ToString();
                    Name.Text = row.Cells["fname"].Value.ToString();
                    textBox2.Text = row.Cells["hourly"].Value.ToString();
                    sss.Text = row.Cells["SSS"].Value.ToString();
                    pagibig.Text = row.Cells["PAG-IBIG"].Value.ToString();
                    philhealth.Text = row.Cells["PHILHEALTH"].Value.ToString();
                    Stat.Text = row.Cells["empstatus"].Value.ToString();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";
            string employeename = Name.Text.Trim();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string queryMonthly = "SELECT `hoursworked` FROM tbmonthly WHERE `Name` = @EmployeeName";
                string queryContractual = "SELECT `hoursworked` FROM tbcontractual WHERE `Name` = @EmployeeName";
                string queryPartTime = "SELECT `hoursworked` FROM tbparttime WHERE `Name` = @EmployeeName";

                using (MySqlCommand commandMonthly = new MySqlCommand(queryMonthly, connection))
                using (MySqlCommand commandContractual = new MySqlCommand(queryContractual, connection))
                using (MySqlCommand commandPartTime = new MySqlCommand(queryPartTime, connection))
                {
                    commandMonthly.Parameters.AddWithValue("@EmployeeName", employeename);
                    commandContractual.Parameters.AddWithValue("@EmployeeName", employeename);
                    commandPartTime.Parameters.AddWithValue("@EmployeeName", employeename);

                    connection.Open();

                    string totalHours = "No records found";

                    // Query tbmonthly
                    using (MySqlDataReader readerMonthly = commandMonthly.ExecuteReader())
                    {
                        if (readerMonthly.Read())
                        {
                            totalHours = readerMonthly["hoursworked"].ToString();
                        }
                    }

                    // Query tbcontractual
                    using (MySqlDataReader readerContractual = commandContractual.ExecuteReader())
                    {
                        if (readerContractual.Read())
                        {
                            totalHours = readerContractual["hoursworked"].ToString();
                        }
                    }

                    // Query tbparttime
                    using (MySqlDataReader readerPartTime = commandPartTime.ExecuteReader())
                    {
                        if (readerPartTime.Read())
                        {
                            totalHours = readerPartTime["hoursworked"].ToString();
                        }
                    }

                    txtResult.Text = totalHours;
                
                }

                double inputValue;
                if (double.TryParse(txtResult.Text, out inputValue))
                {
                    double option1 = 168;
                    double option2 = 40;
                    double option3 = 8;
                    double result;

                    if (inputValue >= option1)
                    {
                        result = inputValue - option1;
                        textBox4.Text = result.ToString();
                    }
                    else if (inputValue >= option2)
                    {
                        result = inputValue - option2;
                        textBox4.Text = result.ToString();
                    }
                    else if (inputValue >= option3)
                    {
                        result = inputValue - option3;
                        textBox4.Text = result.ToString();
                    }
                    else
                    {
                        textBox4.Text = "No option matched.";
                    }
                }
                else
                {
                    textBox4.Text = "Invalid input.";
                }

                double value1, value2;

                if (double.TryParse(txtResult.Text, out value1) && double.TryParse(textBox2.Text, out value2))
                {
                    double result = value1 * value2;
                    textBox3.Text = result.ToString();
                }
                else
                {
                    // Handle invalid input or conversion failure
                    textBox3.Text = "Invalid input";
                }

                double valueA, valueB;

                if (double.TryParse(textBox4.Text, out valueA) && double.TryParse(textBox2.Text, out valueB))
                {
                    double result = valueA * valueB * 1.25;
                    otvalue.Text = result.ToString();
                }
                else
                {
                    // Handle invalid input or conversion failure
                    otvalue.Text = "Invalid input";
                }
            }
       
         }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double valueE, valueF;

            if (double.TryParse(textBox6.Text, out valueE) && double.TryParse(textBox2.Text, out valueF))
            {
                double result = valueE * valueF * 1.30;

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    double previousResult;
                    if (double.TryParse(textBox5.Text, out previousResult))
                    {
                        result += previousResult;
                    }
                }

                textBox5.Text = result.ToString();
            }

            // Disable the checkbox after it has been clicked
            checkBox1.Enabled = false;
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            double valueE, valueF;

            if (double.TryParse(textBox6.Text, out valueE) && double.TryParse(textBox2.Text, out valueF))
            {
                double result = valueE * valueF * 2.00;

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    double previousResult;
                    if (double.TryParse(textBox5.Text, out previousResult))
                    {
                        result += previousResult;
                    }
                }

                textBox5.Text = result.ToString();
            }

            // Disable the checkbox after it has been clicked
            checkBox3.Enabled = false;
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            double valueE, valueF;

            if (double.TryParse(textBox6.Text, out valueE) && double.TryParse(textBox2.Text, out valueF))
            {
                double result = valueE * valueF * 2.60;

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    double previousResult;
                    if (double.TryParse(textBox5.Text, out previousResult))
                    {
                        result += previousResult;
                    }
                }

                textBox5.Text = result.ToString();
            }

            // Disable the checkbox after it has been clicked
            checkBox4.Enabled = false;
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            double valueE, valueF;

            if (double.TryParse(textBox6.Text, out valueE) && double.TryParse(textBox2.Text, out valueF))
            {
                double result = valueE * valueF * 1.50;

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    double previousResult;
                    if (double.TryParse(textBox5.Text, out previousResult))
                    {
                        result += previousResult;
                    }
                }

                textBox5.Text = result.ToString();
            }

            // Disable the checkbox after it has been clicked
            checkBox2.Enabled = false;
           
        }

        private void allowance_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(allowance.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(months.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(pl.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(bonus.Text, out valueJ))
            {
                result += valueJ;
            }

            adresult.Text = result.ToString();
        }

        private void months_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(allowance.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(months.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(pl.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(bonus.Text, out valueJ))
            {
                result += valueJ;
            }

            adresult.Text = result.ToString();
        }

        private void pl_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(allowance.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(months.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(pl.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(bonus.Text, out valueJ))
            {
                result += valueJ;
            }

            adresult.Text = result.ToString();
        }

        private void bonus_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(allowance.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(months.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(pl.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(bonus.Text, out valueJ))
            {
                result += valueJ;
            }

            adresult.Text = result.ToString();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(sss.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(pagibig.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(philhealth.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(tax.Text, out valueJ))
            {
                result += valueJ;
            }

            dcresult.Text = result.ToString();
        }

        private void pagibig_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(sss.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(pagibig.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(philhealth.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(tax.Text, out valueJ))
            {
                result += valueJ;
            }

            dcresult.Text = result.ToString();
        }

        private void philhealth_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(sss.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(pagibig.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(philhealth.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(tax.Text, out valueJ))
            {
                result += valueJ;
            }

            dcresult.Text = result.ToString();
        }

        private void tax_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(sss.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(pagibig.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(philhealth.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(tax.Text, out valueJ))
            {
                result += valueJ;
            }

            dcresult.Text = result.ToString();
        }

        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(textBox3.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(otvalue.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(textBox5.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(adresult.Text, out valueJ))
            {
                result += valueJ;
            }

            textBox8.Text = result.ToString();
        }

        private void otvalue_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(textBox3.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(otvalue.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(textBox5.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(adresult.Text, out valueJ))
            {
                result += valueJ;
            }

            textBox8.Text = result.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(textBox3.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(otvalue.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(textBox5.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(adresult.Text, out valueJ))
            {
                result += valueJ;
            }

            textBox8.Text = result.ToString();
        }

        private void adresult_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(textBox3.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(otvalue.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(textBox5.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(adresult.Text, out valueJ))
            {
                result += valueJ;
            }

            textBox8.Text = result.ToString();
        }

        private void dcresult_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH, valueI, valueJ;
            double result = 0;

            if (double.TryParse(sss.Text, out valueG))
            {
                result += valueG;
            }

            if (double.TryParse(pagibig.Text, out valueH))
            {
                result += valueH;
            }

            if (double.TryParse(philhealth.Text, out valueI))
            {
                result += valueI;
            }

            if (double.TryParse(tax.Text, out valueJ))
            {
                result += valueJ;
            }

            textBox7.Text = result.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH;
            double result = 0;

            if (double.TryParse(textBox8.Text, out valueG))
            {
                result = valueG;
            }

            if (double.TryParse(textBox7.Text, out valueH))
            {
                result -= valueH;
            }

            result = Math.Abs(result);

            textBox9.Text = result.ToString();
        
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            double valueG, valueH;
            double result = 0;

            if (double.TryParse(textBox8.Text, out valueG))
            {
                result = valueG;
            }

            if (double.TryParse(textBox7.Text, out valueH))
            {
                result -= valueH;
            }

            result = Math.Abs(result);

            textBox9.Text = result.ToString();
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            try
            {
                Random random = new Random();
                int primaryKey = random.Next(1000, 9999);

                DateTime currentDate = DateTime.Now;

                string employeeName = Name.Text;
                string employeeID = EMPTX.Text;

                string mycon = "datasource=localhost;Database=dbpayroll;username=root;convert zero datetime=true";

                string insertQuery = "INSERT INTO tbrecord (PrimaryKey, EmployeeName, EmployeeID, DateCreated) " +
                                     "VALUES (@PrimaryKey, @EmployeeName, @EmployeeID, @DateCreated)";

                using (MySqlConnection connection = new MySqlConnection(mycon))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PrimaryKey", primaryKey);
                        command.Parameters.AddWithValue("@EmployeeName", employeeName);
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@DateCreated", currentDate);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Data saved to the database successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Get the current date
            string currentDate = DateTime.Today.ToString("MM/dd/yyyy");

            // Set the font and brush for drawing
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            // Set the position for drawing the text
            float x = 50;
            float y = 50;
            float lineHeight = font.GetHeight(e.Graphics) + 10;

            // Define the label and value positions
            float labelX = x;
            float valueX = x + 200;

            // Draw the header
            e.Graphics.DrawString("MOBILE LAB COMPANY", new Font(font, FontStyle.Bold), brush, x, y);
            y += lineHeight;

            // Draw the employee information
            e.Graphics.DrawString("Employee Name:", font, brush, labelX, y);
            e.Graphics.DrawString(Name.Text, font, brush, valueX, y);
            y += lineHeight;

            e.Graphics.DrawString("ID:", font, brush, labelX, y);
            e.Graphics.DrawString(EMPTX.Text, font, brush, valueX, y);
            y += lineHeight;

            e.Graphics.DrawString("Date:", font, brush, labelX, y);
            e.Graphics.DrawString(currentDate, font, brush, valueX, y);
            y += lineHeight;

            e.Graphics.DrawString("Employee Status:", font, brush, labelX, y);
            e.Graphics.DrawString(Stat.Text, font, brush, valueX, y);
            y += lineHeight;

            // Draw the table headers
            e.Graphics.DrawString("Earnings", new Font(font, FontStyle.Bold), brush, x, y);
            e.Graphics.DrawString("Amount", new Font(font, FontStyle.Bold), brush, x + 200, y);
            e.Graphics.DrawString("Deductions", new Font(font, FontStyle.Bold), brush, x + 400, y);
            e.Graphics.DrawString("Amount", new Font(font, FontStyle.Bold), brush, x + 600, y);
            y += lineHeight;

            // Draw the table lines
            e.Graphics.DrawLine(Pens.Black, x, y, x + 800, y);
            y += lineHeight;

            // Draw the table rows
            DrawRow(e.Graphics, font, brush, x, y, "Basic", textBox3.Text, "TAX", tax.Text);
            y += lineHeight;

            DrawRow(e.Graphics, font, brush, x, y, "OT Payment", otvalue.Text, "SSS", sss.Text);
            y += lineHeight;

            DrawRow(e.Graphics, font, brush, x, y, "Incentives", textBox5.Text, "PAG-IBIG", pagibig.Text);
            y += lineHeight;

            DrawRow(e.Graphics, font, brush, x, y, "Adjustment", adresult.Text, "PHILHEALTH", philhealth.Text);
            y += lineHeight;

            // Draw the table line
            e.Graphics.DrawLine(Pens.Black, x, y, x + 800, y);
            y += lineHeight;

            // Draw the total row
            DrawRow(e.Graphics, font, brush, x, y, "Total Payment", textBox8.Text, "Total Deductions", textBox7.Text);
            y += lineHeight;

            // Draw the net pay row
            e.Graphics.DrawString("Net Pay:", font, brush, labelX, y);
            e.Graphics.DrawString(textBox9.Text, font, brush, valueX, y);
            y += lineHeight;
        }
        private void DrawRow(Graphics graphics, Font font, Brush brush, float x, float y, string label1, string value1, string label2, string value2)
        {
            float labelX = x;
            float valueX = x + 200;

            graphics.DrawString(label1, font, brush, labelX, y);
            graphics.DrawString(value1, font, brush, valueX, y);

            float deductionX = x + 400;
            float deductionValueX = x + 600;

            graphics.DrawString(label2, font, brush, deductionX, y);
            graphics.DrawString(value2, font, brush, deductionValueX, y);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        }

        
        }

       
        
     


