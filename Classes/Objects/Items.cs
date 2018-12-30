
namespace TestAdventure
{
    class Items
    {
        //Private Variables
        private string itemDescription;
        private string itemName;
        private string itemUseText;

        #region variable properties (Get / Set)
        public string GetItemDescriptione() { return itemDescription; }
        public string SetItemDescriptione(string v) { itemDescription = v; return itemDescription; }

        public string GetItemName() { return itemName; }
        public string SetItemName(string v) { itemName = v; return itemName; }

        public string GetItemUseText() { return itemUseText; }
        public string SetItemUseText(string v) { itemUseText = v; return itemUseText; }
        #endregion

    }
}
