using UnityEngine;
using UnityEngine.EventSystems;

namespace Relentless.Inventory
{
    [RequireComponent(typeof(Animator))]
    [AddComponentMenu("Relentless/Inventory/UI/Inventory Slot UI Scaling")]
    public class InventorySlotUIScaling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        public void OnPointerEnter(PointerEventData eventData) => _animator.SetBool("IsScalingUp", true);

        public void OnPointerExit(PointerEventData eventData) => _animator.SetBool("IsScalingUp", false);
    }
}