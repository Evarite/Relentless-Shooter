namespace Relentless.Inventory
{
    [System.Serializable]
    public class InventorySlot
    {
        public ItemData ItemData { get; set; }
        public int Quantity { get; set; }

        public InventorySlot(ItemData itemData, int quantity)
        {
            ItemData = itemData;
            Quantity = quantity;
        }
    }
}
