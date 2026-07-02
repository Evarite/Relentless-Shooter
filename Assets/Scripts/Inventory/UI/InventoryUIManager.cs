using UnityEngine;

namespace Relentless.Inventory.UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI[] _inventorySlots;

        private void OnEnable()
        {
            Debug.Log("Subscribing");
            InventoryController.OnInventoryChanged += RefreshUI;
        }

        private void OnDisable()
        {
            InventoryController.OnInventoryChanged -= RefreshUI;
        }

        private void RefreshUI()
        {
            Debug.Log("Caught the event");
            for (int i = 0; i < _inventorySlots.Length; i++)
                _inventorySlots[i].SetData(InventoryController.GetSlot(i));
        }
    }
}