using System;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private int _inventorySize = 15;
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        public event Action OnInventoryChanged;

        private void Awake()
        {
            for (int i = 0; i < _inventorySize; i++)
                _inventorySlots.Add(new InventorySlot(null, 0));
        }

        public void AddItem(ItemData newItem, int quantity = 1)
        {
            int index = _inventorySlots.FindIndex(slot =>
            slot.ItemData != null &&
            slot.ItemData.IsStackable &&
            slot.Quantity != slot.ItemData.MaxStackSize &&
            slot.ItemData == newItem);

            if (index != -1)
            {
                InventorySlot occupiedSlot = _inventorySlots[index];

                int spaceLeft = occupiedSlot.ItemData.MaxStackSize - occupiedSlot.Quantity;
                int amountToAdd = Mathf.Min(spaceLeft, quantity);

                occupiedSlot.Quantity += amountToAdd;
                quantity -= amountToAdd;

                if (quantity > 0)
                    AddToFreeSlot(newItem, quantity);
            }
            else
            {
                if (!AddToFreeSlot(newItem, quantity))
                    return;
            }

            OnInventoryChanged?.Invoke();
        }

        private bool AddToFreeSlot(ItemData data, int quantity)
        {
            bool addedSuccessfully = false;

            while (quantity > 0)
            {
                int freeIndex = _inventorySlots.FindIndex(slot => slot.ItemData == null);

                if (freeIndex != -1)
                {
                    //_inventorySlots[freeIndex] = new InventorySlot(data,
                    //    Mathf.Min(quantity, data.MaxStackSize));
                    _inventorySlots[freeIndex].ItemData = data;
                    _inventorySlots[freeIndex].Quantity = Mathf.Min(quantity, data.MaxStackSize);

                    Debug.Log($"{data.Name}, {_inventorySlots[freeIndex].ItemData.Name}");
                    quantity -= data.MaxStackSize; //Doesn't matter if that will be negative, but avoids another if block

                    addedSuccessfully = true;
                }
                else
                    break;
            }

            return addedSuccessfully;
        }

        public InventorySlot GetSlot(int index) => _inventorySlots[index];
    }
}