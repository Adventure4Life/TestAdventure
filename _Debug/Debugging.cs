using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TestAdventure
{
    static class DeBugging
    {
        public static void TestSomething()
        {
            //Console.WriteLine(Level.map[0, 0].GetRoomDescription());
            EnglishPorter2Stemmer stemming = new EnglishPorter2Stemmer();

            List<string> wordTest = new List<string>();
            wordTest.Add("nomination");
            wordTest.Add("appointee");
            wordTest.Add("closure");
            wordTest.Add("refusal");
            wordTest.Add("runner");
            wordTest.Add("advertisement");
            wordTest.Add("freedom");
            wordTest.Add("likelihood");
            wordTest.Add("realist");
            wordTest.Add("warmth");
            wordTest.Add("happiness");
            wordTest.Add("look");
            wordTest.Add("looking");
            wordTest.Add("looks");
            wordTest.Add("looked");
            wordTest.Add("taken");
            wordTest.Add("viewing");
            wordTest.Add("regarding");
            wordTest.Add("marking");
            wordTest.Add("beholding");
            wordTest.Add("contemplation");
            wordTest.Add("inspection");
            wordTest.Add("noticing");
            wordTest.Add("observation");
            wordTest.Add("speculation");


            Console.WriteLine("\n");
            Console.WriteLine(@"//--Stolen MIT Stemmer Code Results");
            Console.WriteLine("");
            foreach (string item in wordTest)
            {
                Console.WriteLine(stemming.Stem(item).Unstemmed + " : " + stemming.Stem(item).Value);
            }
            Console.WriteLine("\n");
            Console.WriteLine(@"//--My Own custom Stemmer Results");
            Console.WriteLine("");

            StemWordstToRootForm StemWord = new StemWordstToRootForm();

            //StemWord.wtf("testing");

            foreach (string item in wordTest)
            {
                Console.WriteLine(item + " : " + StemWord.wtf(item));
            }


        }

        public static void Exit()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n*** Press Any Key to Exit ***");
            Console.ReadKey();
        }

    }
}
