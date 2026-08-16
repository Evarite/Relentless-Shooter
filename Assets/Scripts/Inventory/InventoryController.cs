using Relentless.Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Inventory
{
    [AddComponentMenu("Relentless/Inventory/Inventory Controller")]
    public class InventoryController : MonoBehaviour
    {
        public static InventoryController Instance { get; private set; }

        private int _inventorySize = 15;
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        public event Action OnInventoryChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            for (int i = 0; i < _inventorySize; i++)
                _inventorySlots.Add(new InventorySlot(null, 0));
        }

        public void AddItem(ItemData newItem, int count = 1)
        {
            int index = _inventorySlots.FindIndex(slot =>
            slot.ItemData != null &&
            slot.ItemData.IsStackable &&
            slot.Count != slot.ItemData.MaxStackSize &&
            slot.ItemData == newItem);

            if (index != -1)
            {
                InventorySlot occupiedSlot = _inventorySlots[index];

                int spaceLeft = occupiedSlot.ItemData.MaxStackSize - occupiedSlot.Count;
                int amountToAdd = Mathf.Min(spaceLeft, count);

                occupiedSlot.Count += amountToAdd;
                count -= amountToAdd;

                if (count > 0)
                    AddToFreeSlot(newItem, count);
            }
            else
            {
                if (!AddToFreeSlot(newItem, count))
                    return;
            }

            OnInventoryChanged?.Invoke();
        }

        private bool AddToFreeSlot(ItemData data, int count)
        {
            bool addedSuccessfully = false;

            while (count > 0)
            {
                int freeIndex = _inventorySlots.FindIndex(slot => slot.ItemData == null);

                if (freeIndex != -1)
                {
                    _inventorySlots[freeIndex].ItemData = data;
                    _inventorySlots[freeIndex].Count = Mathf.Min(count, data.MaxStackSize);

                    count -= data.MaxStackSize; //Doesn't matter if that will be negative, but avoids another if block

                    addedSuccessfully = true;
                }
                else
                    break;
            }

            return addedSuccessfully;
        }

        public void RemoveItem(int index)
        {
            _inventorySlots[index].ItemData = null;
            _inventorySlots[index].Count = 0;

            OnInventoryChanged?.Invoke();
        }

        public void ChangeSlot(int oldSlot, int newSlot)
        {
            if (_inventorySlots[newSlot].ItemData == null)
            {
                (_inventorySlots[oldSlot], _inventorySlots[newSlot]) =
                    (_inventorySlots[newSlot], _inventorySlots[oldSlot]);
            }
            else if (_inventorySlots[newSlot].ItemData == _inventorySlots[oldSlot].ItemData &&
                _inventorySlots[newSlot].Count != _inventorySlots[newSlot].ItemData.MaxStackSize &&
                _inventorySlots[oldSlot].Count != _inventorySlots[oldSlot].ItemData.MaxStackSize)
            {

            }
            else
                (_inventorySlots[oldSlot], _inventorySlots[newSlot]) =
                    (_inventorySlots[newSlot], _inventorySlots[oldSlot]);

            OnInventoryChanged?.Invoke();
        }

        public InventorySlot GetSlot(int index) => _inventorySlots[index];
    }
}