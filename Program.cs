using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initilise();
            Engine.StartScreen();
            //PrintConsoleBuffer.PrintStory(TextUtils.WordWrap(TextUtils.ReadDataFile()));

            while (GameState.gameIsRunning)
            {
                //DeBugging.TestSomething();
                Engine.PlayGame();
            }

            // Debugging
            DeBugging.Exit();
        }
    }   
}
