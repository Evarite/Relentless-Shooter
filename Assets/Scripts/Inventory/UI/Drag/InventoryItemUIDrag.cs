using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory.UI.Drag
{
    [AddComponentMenu("Relentless/Inventory/UI/Item Drag/Inventory Item UI Drag")]
    public class InventoryItemUIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        //[field: SerializeField] public InventorySlotUI CurrentSlot { private get; set; }

        private RectTransform _rectTransform;
        private Vector2 _clickOffset;

        [SerializeField] private Vector3 _draggingScale;
        [SerializeField] private Transform _layerOnTop;

        private Quaternion _originalRotation = Quaternion.identity;
        private Vector3 _origninalScale = Vector3.one;
        private Vector3 _originalPosition = Vector3.zero; //The position inside the parent object
        private Transform _originalParent;

        //public event Action<InventorySlotUI, PointerEventData> ItemTaken;
        //public event Action<InventorySlotUI, PointerEventData> ItemReleased;
        public event Action<PointerEventData> ItemTaken;
        public event Action<PointerEventData> ItemReleased;

        //Item is not transfered to another slot, the sprites are changed only
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            _originalParent = transform.parent;
        }

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

            transform.SetParent(_layerOnTop, true);
            transform.localScale = _draggingScale;

            //ItemTaken?.Invoke(CurrentSlot, eventData);
            ItemTaken?.Invoke(eventData);
        }

        //public void OnEndDrag(PointerEventData eventData) => ItemReleased?.Invoke(CurrentSlot, eventData);
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localScale = _origninalScale;

            transform.SetParent(_originalParent, false);
            _rectTransform.anchoredPosition3D = _originalPosition;
            transform.rotation = _originalRotation;

            ItemReleased?.Invoke(eventData);
        }
    }
}