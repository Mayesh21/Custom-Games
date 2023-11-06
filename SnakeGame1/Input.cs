using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class Input
    {
        public static Hashtable keyTable= new Hashtable(); //we are creating a new instance of hashtable class
        //this class is used to optimize the keys inserted in it

        public static bool KeyPress(Keys key)
        {
            //this function will return a key back to the class
            if (keyTable[key] == null)
            {
                //if hashtable is empty, then we return false
                return false;
            }
            //if Hashtable is not empty, then we return true
            return (bool)keyTable[key];
        }
        public static void changeState(Keys key, bool state)
        {
            //this function will change state of the key and the player with it
            //this function has two arguements key and state

            keyTable[key] = state;
        }
    }
}
