using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Gmaes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/SnakeGame1/bin/Debug/SnakeGame1.exe");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/SnakeGame1/bin/Debug/SnakeGame1.exe");

        }
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/SnakeGame1/bin/Debug/SnakeGame1.exe");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/CarRacing/bin/Debug/CarRacing.exe");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/CarRacing/bin/Debug/CarRacing.exe");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("D:/MSC/FY Programs/C# programs/Custom Gmaes/CarRacing/bin/Debug/CarRacing.exe");

        }
    }
}
