using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{ 
    
    static class Player
    {
        // Public Variables.
        public static int xRow { get; set; } = 0;
        public static int yCol { get; set; } = 0;

        //Private Variables.
        private static List<Items> inventoryItems = new List<Items>();

    }
}
