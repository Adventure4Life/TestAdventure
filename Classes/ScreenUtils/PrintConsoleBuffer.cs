using System;
using System.Threading;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TestAdventure
{
    static class PrintConsoleBuffer
    {
        #region PrintStory Methods
        // This is for use with threading. Thread t = new Thread(KeyPressed);t.Start();
        // It Allows you to looks for a keystroke even if the application is doing something else
        // The KeyPressed Method simple changed a bool on that key press to be used to break a loop.
        static private bool breakLoop = false;
        static void KeyPressed()
        {
            while (!Console.KeyAvailable || breakLoop) { } // just do nothing while the other code prints to screen.
            Console.ReadKey(false); // keyAvalible test dose not stop the input of the key.. so this is here to catch that. True means no cursor
            breakLoop = true;
        }

        // This actually prints the given line. Character by Character. Pressing any key will skip to end!
        public static void PrintStory(string line)
        {
            Console.CursorVisible = false;
            Thread t = new Thread(KeyPressed);
            t.Start();
            while (!breakLoop)
            {
                //foreach (char c in line)
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    Console.Write(c);
                    Thread.Sleep(5);
                    if (breakLoop)
                    {
                        Console.Write(line.Substring(i, line.Length - i));
                        break;
                    }
                }
               breakLoop = true;
            }
            t.Abort();
            Console.CursorVisible = true;
        }
        #endregion
    }
}
