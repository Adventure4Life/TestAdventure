using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace TestAdventure
{
    static class DeBugging
    {
        public static void Exit()
        {
            Console.CursorVisible = false;
            //Console.ReadKey();
            Console.WriteLine("\n*** Press Any Key to Exit ***");
            Console.ReadKey();
        }
    }
}
