namespace Relentless.Inventory
{
    public class InventorySlot
    {
        public ItemData ItemData { get; set; }
        public int Count { get; set; }

        public InventorySlot(ItemData itemData, int count)
        {
            ItemData = itemData;
            Count = count;
        }
    }
}
