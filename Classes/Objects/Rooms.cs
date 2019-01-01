using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{ 
    class Rooms
    {
        //Private Variables
        private string roomName = "<roomName goes here>";
        private string roomBaseDescription = "<description goes here>";
        private List<Items> itemsInRoom  = new List<Items>();
        private List<Exit> exitsFromRoom  = new List<Exit>();

        #region variable properties (Gets)
        public string GetRoomName() { return roomName; }
        
        public string GetRoomDescription() { return roomBaseDescription; }
        
        public List<Items> GetItemsInRoom() { return itemsInRoom; }
        
        public List<Exit> GetExitsInRoom() { return exitsFromRoom; }
        #endregion
        
        #region variable properties (Sets)
        public void SetRoom_NameVariable(string importLine)
        {
            roomName = importLine;
        }

        public void SetRoom_BaseDescription(string importLine)
        {
            roomBaseDescription = importLine;
        }

        public void SetRoom_AddExit(Exit exit)
        {
            exitsFromRoom.Add(exit);
        }

        public void SetRoom_AddItem(Items item)
        {
            itemsInRoom.Add(item);
        }

        //public List<string> SetExitsofRoom(string v) { exitsRoom.Add(v); return exitsRoom; }
        public List<Items> AddItemToRoom(Items v) { this.itemsInRoom.Add(v); return itemsInRoom; }
        #endregion
    }
}