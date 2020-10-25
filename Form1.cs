using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        fun funt = new fun();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funt.LoadOriginalImage();
            pictureBox1.ImageLocation = "1.jpg";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            funt.sobel();
            pictureBox2.ImageLocation = "sobelx.jpg";
            pictureBox3.ImageLocation = "sobely.jpg";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            funt.laplationwithoutnoice();
            pictureBox4.ImageLocation = "lap2.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
           funt.laplationwithoutnoice();
            pictureBox5.ImageLocation = "lap2.jpg";
        }
    }
}
