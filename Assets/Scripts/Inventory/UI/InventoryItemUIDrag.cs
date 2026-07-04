using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory.UI
{
    [AddComponentMenu("Relentless/Inventory/UI/Inventory Item UI Drag")]
    public class InventoryItemUIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        //[field: SerializeField] public InventorySlotUI CurrentSlot { private get; set; }

        private RectTransform _rectTransform;
        private Vector2 _clickOffset;

        //public event Action<InventorySlotUI, PointerEventData> ItemTaken;
        //public event Action<InventorySlotUI, PointerEventData> ItemReleased;
        public event Action<PointerEventData> ItemTaken;
        public event Action<PointerEventData> ItemReleased;

        private void Awake() => _rectTransform = GetComponent<RectTransform>();

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint
                );

            _rectTransform.anchoredPosition = localPoint + _clickOffset;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint
                );

            _clickOffset = _rectTransform.anchoredPosition - localPoint;

            //ItemTaken?.Invoke(CurrentSlot, eventData);
            ItemTaken?.Invoke(eventData);
        }

        //public void OnEndDrag(PointerEventData eventData) => ItemReleased?.Invoke(CurrentSlot, eventData);
        public void OnEndDrag(PointerEventData eventData) => ItemReleased?.Invoke(eventData);
    }
}
