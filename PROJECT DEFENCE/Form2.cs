using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJECT_DEFENCE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Visible = false;
            fr2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Visible = false;
            fr3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Visible = false;
            fr4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Visible = false;
            fr5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Visible = false;
            fr6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure do you want to log out?", "Important Question", MessageBoxButtons.YesNo);
            String Query = "";
            if (result1.Equals(DialogResult.Yes))
            {
                Form1 fr1 = new Form1();
                fr1.Show();
                this.Hide();
            }
            else
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Create the ToolTip instance
            toolTip = new ToolTip();

            // Set the desired text for the pop-up tooltip
            string tooltipText = "This is a pop-up text.";

            // Associate the ToolTip with the PictureBox
            toolTip.SetToolTip(pictureBox1, tooltipText);

            // Create and configure the timer
            timer = new Timer();
            timer.Interval = 2000; // Change phrase every 2 seconds
            timer.Tick += timer1_Tick;
            timer.Start();

            // Set initial label text
            label6.Text = phrases[currentIndex];

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


      

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            // Create the ToolTip instance if it doesn't exist
            if (toolTip == null)
                toolTip = new ToolTip();

            // Set the desired text for the pop-up tooltip
            string tooltipText = "Next";

            // Show the tooltip relative to the PictureBox
            toolTip.Show(tooltipText, pictureBox2);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(pictureBox2);
        }

        private ToolTip toolTip;

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            // Create the ToolTip instance if it doesn't exist
            if (toolTip == null)
                toolTip = new ToolTip();

            // Set the desired text for the pop-up tooltip
            string tooltipText = "Back";

            // Show the tooltip relative to the PictureBox
            toolTip.Show(tooltipText, pictureBox3);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(pictureBox3);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Visible = false;
            fr3.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Move to the next phrase
            currentIndex = (currentIndex + 1) % phrases.Length;

            // Update the label text
            label6.Text = phrases[currentIndex];
        }



        private Timer timer;
        private string[] phrases = { "Payroll checking", "What would you like to do today?", "Hello world", "Nice to meet you", "Good Morning", "Creating paychecks for employees" , "Hot coffee for coding" }; 
        private int currentIndex = 0;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (panel3.Visible)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }
        }

       
       

     
      
        
       
      
    }
}
