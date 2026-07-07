using UnityEngine;

namespace Relentless.Inventory.UI
{
    [AddComponentMenu("Relentless/Inventory/UI/Inventory UI Manager")]
    public class InventoryUIManager : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI[] _inventorySlots;

        public static InventoryUIManager Instance { get; private set; }

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnEnable() => InventoryController.OnInventoryChanged += RefreshUI;

        private void OnDisable() => InventoryController.OnInventoryChanged -= RefreshUI;

        private void RefreshUI()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
                _inventorySlots[i].SetData(InventoryController.GetSlot(i));
        }

        public static int GetSlotIndex(InventorySlotUI slot)
        {
            for (int i = 0; i < Instance._inventorySlots.Length; i++)
                if (slot == Instance._inventorySlots[i])
                    return i;
            return -1;
        }
    }
}