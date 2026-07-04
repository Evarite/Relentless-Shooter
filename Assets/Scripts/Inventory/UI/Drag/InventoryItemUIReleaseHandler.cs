using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory.UI.Drag
{
    [RequireComponent(typeof(InventorySlotUI))]
    [AddComponentMenu("Relentless/Inventory/UI/Item Drag/Inventory Item UI Release Handler")]
    public class InventoryItemUIReleaseHandler : MonoBehaviour
    {
        [SerializeField] private InventoryItemUIDrag _itemDrag;

        private InventorySlotUI _slot;

        public event Action<InventorySlotUI> OnChangeSlot;
        public event Action OnItemDrop;

        private void Awake() => _slot = GetComponent<InventorySlotUI>();

        private void OnEnable()
        {
            _itemDrag.ItemReleased += ItemReleased;
        }

        private void OnDisable()
        {
            _itemDrag.ItemReleased -= ItemReleased;
        }

        private void ItemReleased(PointerEventData eventData)
        {
            List<RaycastResult> raycastResults = new();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            InventorySlotUI targetSlot = null;

            foreach (var result in raycastResults)
            {
                targetSlot = result.gameObject.GetComponent<InventorySlotUI>();
                if (targetSlot != null)
                {
                    Debug.Log("Slot detected!");
                    OnChangeSlot?.Invoke(_slot);
                    return;
                }
            }
             
            Debug.Log("No slot detected");
            OnItemDrop?.Invoke();
        }
    }
}