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
            Console.WriteLine(Level.Layout[0, 0].GetRoomName());
            Console.WriteLine(Level.Layout[0, 0].GetRoomDescription());
            
            foreach (Exit exit in Level.Layout[0, 0].GetExitsInRoom())
            {
                Console.WriteLine("\n"+exit.name);
                Console.WriteLine(exit.open);
                if (exit.look_room_open != "" ) { Console.WriteLine(exit.look_room_open); }
                if (exit.look_room_closed != "") { Console.WriteLine(exit.look_room_closed); }
                if (exit.look_at_closed != "") { Console.WriteLine(exit.look_at_closed); }
                if (exit.look_at_open != "") { Console.WriteLine(exit.look_at_open); }
                if (exit.use_blocked != "") { Console.WriteLine(exit.use_blocked); }
                if (exit.use_unblocked != "") { Console.WriteLine(exit.use_unblocked); }
            }

            foreach (Items item in Level.Layout[0, 0].GetItemsInRoom())
            {
                Console.WriteLine("\n" + item.itemName);
                Console.WriteLine(item.canBeGot);
                //if (item.itemDescription_Default != "") { Console.WriteLine(item.itemDescription_Default); }
                //if (item.itemDescription_Dropped != "") { Console.WriteLine(item.itemDescription_Dropped); }
                //if (item.itemDescription_Gone != "") { Console.WriteLine(item.itemDescription_Gone); }
                //if (item.getItem_Success != "") { Console.WriteLine(item.getItem_Success); }
                //if (item.getItem_NotAllowed != "") { Console.WriteLine(item.getItem_NotAllowed); }
            }
        }

        public static void TestTokenAndClean()
        {
            string testString = "nomination appointee closure refusal runner advertisement freedom likelihood realist warmth happiness look looking looks looked taken viewing regarding marking beholding contemplation inspection noticing observation speculation";
            List<string> wordTest = new List<string>();

                Console.WriteLine("*** TEST STRING ***");
                Console.WriteLine(testString);
                Console.WriteLine("\n");

                Console.WriteLine("*** TEST TOKENISATION ***");
            wordTest = TextUtils.TokenizeString(testString);
                Console.WriteLine("\n");

            foreach (string item in wordTest)
            {
                Console.WriteLine(item);
            }

                Console.WriteLine("*** TEST STEMMING ***");
            wordTest = TextUtils.RoughStemming(wordTest);
                Console.WriteLine("\n");
            foreach (string item in wordTest)
            {
                Console.WriteLine(item);
            }

        }

        public static void Test_Stemmer()
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
/*
 *             Console.WriteLine("\n" + Level.Layout[0, 0].GetExitsInRoom()[0].name);
            if (Level.Layout[0, 0].GetExitsInRoom()[0].look_room_open != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].look_room_open); }
            if (Level.Layout[0, 0].GetExitsInRoom()[0].look_room_closed != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].look_room_closed); }
            if (Level.Layout[0, 0].GetExitsInRoom()[0].look_at_closed != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].look_at_closed); }
            if (Level.Layout[0, 0].GetExitsInRoom()[0].look_at_open != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].look_at_open); }
            if (Level.Layout[0, 0].GetExitsInRoom()[0].use_blocked != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].use_blocked);}
            if (Level.Layout[0, 0].GetExitsInRoom()[0].use_unblocked != "") { Console.WriteLine(Level.Layout[0, 0].GetExitsInRoom()[0].use_unblocked);}
*/