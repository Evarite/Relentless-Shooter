using UnityEngine;

namespace Relentless.Inventory.UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI[] _inventorySlots;
        [SerializeField] private InventoryController _controller;

        private void OnEnable()
        {
            _controller.OnInventoryChanged += RefreshUI;
        }

        private void OnDisable()
        {
            _controller.OnInventoryChanged -= RefreshUI;
        }

        private void RefreshUI()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
                _inventorySlots[i].SetData(_controller.GetSlot(i));
        }
    }
}