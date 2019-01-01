using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class Level
    {
        //Public Variable
        public static Rooms[,] Layout { get; set; } = new Rooms[2, 2];

        public static void InitiliseLevel()
        {
            Layout[0, 0] = DataReader.ImportRoomData("TestRoom");
        }
    }
}