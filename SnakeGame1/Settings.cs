using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Directions
    {
        //this is a enum class called Directions
        //we are using enum because it is easier to classify the direction for the game
        Left,
        Right,
        Up,
        Down,
    };
    internal class Settings
    {
        public static int Width { get; set; }//set the width as Int class
        public static int Height { get; set; }//set the height as Int class
        public static int Speed { get; set; }//set the Speed as Int class
        public static int Score { get; set; }//set the Score as Int class
        public static int Points { get; set; }//set the Points as Int class
        public static bool GameOver { get; set; }//set the Gameover as Boolean class
        public static Directions direction { get; set; }//set the direction as the class we mentioned above


        public Settings()
        {
            //this is the default setting function
            Width = 16;//Set width to 16
            Height = 16;//Set height to 16
            Speed = 20;//Set Speed to 20
            Score = 0;//Set Score to 0
            Points = 100;//Set Points to 100
            GameOver = false;//Set GameOVer to false
            direction = Directions.Down;//Set direction to down
        }
    }
}
