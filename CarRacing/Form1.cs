using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameOver.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gameSpeed);
            enemy(gameSpeed-2);
            gameOver();
            coin(gameSpeed);
            coincollection();
        }
        Random r= new Random();
        int x, y,collected=0;
        
        void enemy(int speed)
        {
            if (Enemy1.Top >= 500)
            {
                x = r.Next(20, 125);
                Enemy1.Location = new Point(x,0);
            }
            else
            {
                Enemy1.Top += speed;
            }
            if (Enemy2.Top >= 500)
            {
                x = r.Next(125, 186);
                Enemy2.Location = new Point(x, 0);
            }
            else
            {
                Enemy2.Top += speed;
            }
            if (Enemy3.Top >= 500)
            {
                x = r.Next(186, 250);
                Enemy3.Location = new Point(x, 0);
            }
            else
            {
                Enemy3.Top += speed;
            }

        }
        void coin(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(20, 125);
                coin1.Location = new Point(x,0);
            }
            else
            {
                coin1.Top += speed;
            }
            if (coin2.Top >= 500)
            {
                x = r.Next(125, 186);
                coin2.Location = new Point(x, 0);
            }
            else
            {
                coin2.Top += speed;
            }
            if (coin3.Top >= 500)
            {
                x = r.Next(186, 250);
                coin3.Location = new Point(x, 0);
            }
            else
            {
                coin3.Top += speed;
            }
            if (coin4.Top >= 500)
            {
                x = r.Next(186, 250);
                coin4.Location = new Point(x, 0);
            }
            else
            {
                coin4.Top += speed;
            }

        }

        void gameOver()
        {
            if(car.Bounds.IntersectsWith(Enemy1.Bounds) || car.Bounds.IntersectsWith(Enemy2.Bounds) || car.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                timer1.Enabled = false;
                gameSpeed = 0;
                GameOver.Visible = true;
                //car.Visible = false;
            }
        }
        void moveline(int speed)
        {
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }
            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }
            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }
            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }
        }
        void coincollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collected++;
                label1.Text = "Coins=" + collected.ToString();
                x = r.Next(0, 250);
                coin1.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collected++;
                label1.Text = "Coins=" + collected.ToString();
                x = r.Next(0, 250);
                coin2.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collected++;
                label1.Text = "Coins=" + collected.ToString();
                x = r.Next(0, 250);
                coin3.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collected++;
                label1.Text = "Coins=" + collected.ToString();
                x = r.Next(0, 250);
                coin4.Location = new Point(x, 0);
            }

        }

        int gameSpeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && car.Left>20) 
            {
                car.Left -= gameSpeed;
            }
            if(e.KeyCode == Keys.Right && car.Right <270) 
            {
                car.Left += gameSpeed;
            }
            if (e.KeyCode == Keys.Up && gameSpeed<21 && timer1.Enabled==true)
            {
                gameSpeed++;
            }
            if (e.KeyCode == Keys.Down && gameSpeed>0 && timer1.Enabled == true)
            {
                gameSpeed--;
            }
        }
    }
}
