using UnityEngine;

namespace Relentless.Inventory.UI.Drag
{
    [RequireComponent(typeof(InventorySlotUI))]
    [RequireComponent(typeof(InventoryItemUIReleaseHandler))]
    public class InventoryItemUIChangeSlotHandler : MonoBehaviour
    {
        private InventorySlotUI _slot;
        private InventoryItemUIReleaseHandler _releaseHandler;

        private void Awake()
        {
            _slot = GetComponent<InventorySlotUI>();
            _releaseHandler = GetComponent<InventoryItemUIReleaseHandler>();
        }

        private void OnEnable() => _releaseHandler.OnChangeSlot += ChangeSlot;

        private void OnDisable() => _releaseHandler.OnChangeSlot -= ChangeSlot;

        private void ChangeSlot(InventorySlotUI newSlot) =>
            InventoryController.ChangeSlot(InventoryUIManager.GetSlotIndex(_slot),
                InventoryUIManager.GetSlotIndex(newSlot));
    }
}