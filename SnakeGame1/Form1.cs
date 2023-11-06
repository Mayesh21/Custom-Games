using SnakeGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SnakeGame1
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake=new List<Circle> ();//Creating a list array for snake
        private Circle food=new Circle ();//create a single circle called food

        public Form1()
        {
            InitializeComponent();
            new Settings();//Linking the setting class to the form
            gameTimer.Interval = 1000/Settings.Speed;//Changing the game time to setting speed
            gameTimer.Tick += updateScreen;//linking updateScreen function to the timer
            gameTimer.Start();//Starting the timer
            startGame();//running the startgame function
        }
        private void updateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver == true)
            {
                //if game over is true and player press enter we run the start game function
                if (Input.KeyPress(Keys.Enter))
                {
                    startGame();
                }
            }
            else
            {
                //if game is not over, the following commands will be executed
                if (Input.KeyPress(Keys.Right) && Settings.direction!=Directions.Left)
                {
                    Settings.direction =Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction!=Directions.Right)
                {
                    Settings.direction =Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction!=Directions.Down)
                {
                    Settings.direction =Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction!=Directions.Up)
                {
                    Settings.direction =Directions.Down;
                }
                movePlayer();//run move player function
            }
            pbCanvas.Invalidate ();//refresh the picture box and update the graphics
        }

        private void movePlayer()
        {
            //the main loop for the snake head and parts
            for (int i=Snake.Count-1; i>=0; i--)
            {
                //if snack head is active
                if (i == 0)
                {
                    //move rest of the body according to which way the head is moving
                    switch(Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++; 
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }
                    //restrict the snake from leaving the canvas
                    int maxXpos=pbCanvas.Size.Width/Settings.Width;
                    int maxYpos=pbCanvas.Size.Height/Settings.Height;

                    if (Snake[i].X<0 || Snake[i].Y<0 || Snake[i].X>maxXpos || Snake[i].Y>maxYpos)
                    {
                        //end the game either reaches edge of the canvas
                        die();
                    }
                    //detect collision with the body
                    //this loop will check if the snake had collision with other body part
                    for(int j=1;j<Snake.Count;j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            //if so we run the die function
                            die();
                        }
                    }
                    //detect collision between snake head and food
                    if (Snake[0].X==food.X && Snake[0].Y == food.Y)
                    {
                        //if we so run the eat function
                        eat();
                    }
                }
                else
                {
                    //if there are no collision then we continue moving the snake and its part
                    Snake[i].X = Snake[i-1].X;
                    Snake[i].Y = Snake[i-1].Y;

                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            //the key down event will trigger the change the state from the input class
            Input.changeState(e.KeyCode, true);
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            //the key up event will trigger the change the state from the input class
            Input.changeState(e.KeyCode, false);

        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            //this is where we will see the snake and its part moving
            Graphics canvas= e.Graphics;//Create new graphics class called canvas
            if(Settings.GameOver == false)
            {
                //if game is not over then we do the following
                Brush snakeColour;//create a new brush for snake color

                for(int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        //color the head of snake
                        snakeColour =Brushes.Black;
                    }
                    else
                    {
                        //color the rest of snake body green
                        snakeColour = Brushes.Green;
                    }
                    //Draw snake body and head
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(
                            Snake[i].X * Settings.Width, 
                            Snake[i].Y*Settings.Height,
                            Settings.Width, Settings.Height));
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(
                            food.X*Settings.Width,food.Y*Settings.Height,Settings.Width,Settings.Height));
                }
            }
            else
            {
                //this part will run when the game is over
                //it will show the game over message and make the lable 3 visible on the screen
                string GameOver = "Game Over\n" + "Final Score is: "+Settings.Score+"\nPress enter to restart\n";
                label3.Text = GameOver;
                label3.Visible = true;
            }
        }
        private void startGame()
        {
            //this is start game function
            label3.Visible= false;
            new Settings();
            Snake.Clear();
            Circle head= new Circle { X=10,Y=5};//Create a new head for the snake
            Snake.Add(head);//Add the head to the snake array
            label2.Text=Settings.Score.ToString();//Show score
            generateFood();
        }
        private void generateFood()
        {
            int maxXpos = pbCanvas.Size.Width / Settings.Width;
            int maxYpos = pbCanvas.Size.Height / Settings.Height;
            Random rnd = new Random();
            food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };
        }//Create a new food with random x and y

        private void eat()
        {
            //add a part to body
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].X
            };
            Snake.Add(body);
            Settings.Score+=Settings.Points;
            label2.Text=Settings.Score.ToString();
            generateFood() ;
        }
        private void die()
        {
            //change game over bool to true
            Settings.GameOver = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
