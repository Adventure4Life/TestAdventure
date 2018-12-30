using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{ 
    class Rooms
    {
        //public Variables
        private string roomName = "Default Blank Room";
        private string roomDescription = "<description goes here>";
        private List<Items> itemsInRoom  = new List<Items>();
        private List<string> exitsRoom  = new List<string>();

        #region variable properties (Get / Set)
        public string GetRoomName() { return roomName; }
        public string SetRoomName(string v) { roomName = v;  return roomName; }

        public string GetRoomDescription() { return roomDescription; }
        public string SetRoomDescription(string v) { roomDescription = v; return roomDescription; }

        public List<Items> GetItemsInRoom() { return itemsInRoom; }
        public List<Items> AddItemToRoom(Items v) { this.itemsInRoom.Add(v); return itemsInRoom; }

        public List<string> GetExitsInRoom() { return exitsRoom; }
        public List<string> SetExitsofRoom(string v) { exitsRoom.Add(v); return exitsRoom; }
        #endregion
    }
}