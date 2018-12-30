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
        public static Rooms[,] map { get; set; } = new Rooms[2, 2];

        public static void InitiliseLevel()
        {
            Rooms room = new Rooms();
            room.SetRoomName("Test Room 01");
            room.SetRoomDescription("This is a very empty looking room. Maybe a hanger or something. It appears to be used to test things.");
            room.SetExitsofRoom("_DeadEnd");
            

            Items item = new Items();
            item.SetItemName("Wooden Chair");
            item.SetItemDescriptione("The chair looks like it is made out of plywood.");
            item.SetItemUseText("You walk over to the chair and sit on it.");
            room.AddItemToRoom(item);

            item = new Items();
            item.SetItemName("Table");
            item.SetItemDescriptione("The table looks solid. Like it is made of redwood or oak or something.");
            item.SetItemUseText("How would you use it?");
            room.AddItemToRoom(item);

            item = new Items();
            item.SetItemName("Plank");
            item.SetItemDescriptione("The wooden plank is lying on the ground next to the table. It seems like as solid as the table itself.");
            item.SetItemUseText("This text field seems lame and unneeded!");
            room.AddItemToRoom(item);

            map[0, 0] = room;
        }
    }
}
