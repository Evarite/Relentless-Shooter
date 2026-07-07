using UnityEngine;

namespace Relentless.Inventory.UI
{
    [RequireComponent(typeof(Animator))]
    [AddComponentMenu("Relentless/Inventory/UI/Inventory UI Disable")]
    public class InventoryUIDisable : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnCloseAnimationFinished()
        {
            if (_animator.IsInTransition(0))
                return;

            gameObject.SetActive(false);
        }
    }
}