
namespace TestAdventure
{
    class Items
    {
        //Private Variables
        public string itemName { get; set; } = "";
        public bool canBeGot { get; set; } = true;
        public string itemDescription_Default { get; set; } = "";
        public string itemDescription_Dropped { get; set; } = "";
        public string itemDescription_Gone { get; set; } = "";
        public string getItem_NotAllowed { get; set; } = "";
        public string getItem_Success { get; set; } = "";
    }
}
