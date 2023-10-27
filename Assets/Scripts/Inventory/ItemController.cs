
namespace BlueGravityTest
{

    [System.Serializable]
    public class ItemController
    {
        Item itemData;
        int stackSize;
        public int GetStackSize()
        {
            return stackSize;
        }
        public void addToStack()
        {
            stackSize++;
        }
        public void RemoveFromStack()
        {
            stackSize--;
        }
        public ItemController(Item aItemData)
        {
            itemData = aItemData;
            addToStack();
        }
        public Item getItemData()
        {
            return itemData; 
        }
    }
}