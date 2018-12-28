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
            //string testString = "This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!! This is a long string that I am testing!!";
            //PrintConsoleBuffer.PrintStory(ConsoleUtils.WordWrap(testString));

            PrintConsoleBuffer.PrintStory(ConsoleUtils.WordWrap(ConsoleUtils.ReadDataFile()));
                      

            // Debugging
            DeBugging.Exit();
        }
    }
}
