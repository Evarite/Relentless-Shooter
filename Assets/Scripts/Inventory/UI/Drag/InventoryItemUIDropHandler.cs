using Relentless.Items;
using UnityEngine;

namespace Relentless.Inventory.UI.Drag
{
    [RequireComponent(typeof(InventorySlotUI))]
    [RequireComponent(typeof(InventoryItemUIReleaseHandler))]
    public class InventoryItemUIDropHandler : MonoBehaviour
    {
        private InventorySlotUI _slot;
        private InventoryItemUIReleaseHandler _releaseHandler;

        private void Awake()
        {
            _slot = GetComponent<InventorySlotUI>();
            _releaseHandler = GetComponent<InventoryItemUIReleaseHandler>();
        }

        private void OnEnable() => _releaseHandler.OnItemDrop += DropItem;

        private void OnDisable() => _releaseHandler.OnItemDrop -= DropItem;

        private void DropItem()
        {
            InventorySlot slot = InventoryController.Instance.GetSlot(
                InventoryUIManager.Instance.GetSlotIndex(_slot));

            ItemDropManager.SpawnDroppedItem(slot.ItemData.Prefab, slot.Count);

            InventoryController.Instance.RemoveItem(InventoryUIManager.Instance.GetSlotIndex(_slot));
        }
    }
}