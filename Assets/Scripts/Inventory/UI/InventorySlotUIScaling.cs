using Relentless.Inventory.UI;
using Relentless.Inventory.UI.Drag;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(InventorySlotUI))]
    [AddComponentMenu("Relentless/Inventory/UI/Inventory Slot UI Scaling")]
    public class InventorySlotUIScaling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private InventoryItemUIDrag _itemDrag;
        
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        private void OnEnable()
        {
            _itemDrag.ItemTaken += OnBeginDrag;
            _itemDrag.ItemReleased += OnEndDrag;
        }

        private void OnDisable()
        {
            _itemDrag.ItemTaken -= OnBeginDrag;
            _itemDrag.ItemReleased -= OnEndDrag;
        }

        public void OnPointerEnter(PointerEventData eventData) => _animator.SetBool("IsScalingUp", true);

        public void OnPointerExit(PointerEventData eventData) => _animator.SetBool("IsScalingUp", false);

        public void OnBeginDrag(PointerEventData eventData) => _animator.SetBool("IsBeingDragged", true);

        public void OnEndDrag(PointerEventData eventData) => _animator.SetBool("IsBeingDragged", false);
    }
}