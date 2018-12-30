using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    class StemWordstToRootForm
    {


        public string wtf(string word)
        {
            string stemedWord = word;
            string[] suffixList = new string[14] { "ation", "ee", "ure", "al", "er", "ment", "dom", "hood", "th", "ness", "ing", "s", "ed", "en" };


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


/*
        private readonly char[] _vowels = "aeiouy".ToArray();
        public char[] Vowels { get { return _vowels; } }

        private bool IsVowel(char c)
            { return Vowels.Contains(c);}

        private bool IsConsonant(char c)
            { return !Vowels.Contains(c);}

        string zzz = "what teh fuck";
     
*/
