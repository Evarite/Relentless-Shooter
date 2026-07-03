using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory.UI
{
    [AddComponentMenu("Relentless/Inventory/UI/Inventory Item UI Drag")]
    public class InventoryItemUIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;
        private Vector2 _clickOffset;

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
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform.parent as RectTransform,
                eventData.position, eventData.pressEventCamera, out localPoint);

            _clickOffset = _rectTransform.anchoredPosition - localPoint;
        }

        public void OnEndDrag(PointerEventData eventData) => ItemReleased?.Invoke(eventData);
    }
}
