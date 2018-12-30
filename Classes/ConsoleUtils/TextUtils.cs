﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class TextUtils
    {
        //Public Variables
        
        /// <summary>
        /// ReadDataFile : Unfinshed Read File Method
        /// </summary>
        /// <returns></returns>
        public static string ReadDataFile()
        {
            string text = File.ReadAllText(@"_Debug\testData.txt");
            return text;
        }

        /// <summary>
        /// WordWrap : Makes sure large strings conform to the wdith of the console
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

        /// <summary>
        /// Takes a string, cleans it of punctuation, sets to Lower and then tokenizes the words
        /// </summary>
        /// <param name="string to clean and tokenize"></param>
        /// <returns></returns>
        public static List<string> TokenizeString(string input)
        {
            List<string> cleanedInputString = new List<string>();
            string[] raw_cleanedInputString = input.ToLower().Trim().Split(null);
            
            foreach (string word in raw_cleanedInputString)
            {
                if (word != "")
                {
                    string stripWord = roughStemming(word);
                    stripWord = Regex.Replace(stripWord, @"\p{P}", "");
                    cleanedInputString.Add(stripWord);
                    Console.WriteLine(stripWord);
                }
            }
           return cleanedInputString;
        }

        private static string roughStemming(string word)
        {
            string stemedWord = word;
            string[] suffixList = new string[15] { "'s", "ation", "ee", "ure", "al", "er", "ment", "dom", "hood", "th", "ness", "ing", "s", "ed", "en" };


            // Loop through and test each string.
            foreach (string suffix in suffixList)
            {
                if (word.EndsWith(suffix))
                {
                    int s = word.Length - word.Length;
                    int l = word.Length - suffix.Length;
                    //Console.WriteLine(word.Substring(s, l));
                    //return;
                    stemedWord = word.Substring(s, l);
                }
            }
            return stemedWord;
        }



    }
}