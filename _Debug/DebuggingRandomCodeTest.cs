using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestAdventure
{
    static class DebuggingRandomCodeTest
    {
        public static void Test()
        {
            Console.WriteLine("Press ESC to stop");
           do
           {
                while (!Console.KeyAvailable)
                {
                    // Do something
                    Console.Write('a');
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }

        static private bool breakLoop = false;
        public static void PrintStoryTest(string line)
        {
            Console.CursorVisible = false;
            do
            {
                while (!Console.KeyAvailable)
                {
                    while (!breakLoop)
                    {
                        //foreach (char c in line)
                        for (int i = 0; i < line.Length; i++)
                        {
                            char c = line[i];
                            Console.Write(c);
                            Thread.Sleep(25);
                            if (breakLoop)
                            {
                                Console.Write(line.Substring(i, line.Length - i));
                                break;
                            }
                        }
                        breakLoop = true;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar || !breakLoop);
            //t.Abort();
            Console.CursorVisible = true;
        }

    }
}
