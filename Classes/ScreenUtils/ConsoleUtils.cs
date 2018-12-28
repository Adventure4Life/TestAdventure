using System;
using System.IO;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace TestAdventure
{
    static class ConsoleUtils
    {

        public static string ReadDataFile()
        {
            string text = File.ReadAllText(@"_Debug\testData.txt");
            return text;
        }

        /// <summary>
        /// WordWrap a long string input
        /// </summary>
        /// <param name="text">Input String to edit based on console Width so it word Wraps</param>
        /// <returns></returns>
        public static string WordWrap(string text)
        {
            string result = "";
            int bufferWidth = Console.WindowWidth;
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                int linelength = 0;
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (word.Length + linelength >= bufferWidth - 1)
                    {
                        result += "\n";
                        linelength = 0;
                    }
                    result += word + " ";
                    linelength += word.Length + 1;
                }
                result += "\n";
            }
            return result;
        }
    }

}

/*
 *                 string padline = line.PadLeft(3);
                int linelength = 0;
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (word.Length + linelength >= bufferWidth - 1)
                    {
                        result += "\n";
                        linelength = 0;
                    }
                    result += word + " ";
                    linelength += word.Length + 1;
                }
                result += "\n";
*/