using Relentless.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Inventory.UI
{
    [AddComponentMenu("Relentless/Inventory/UI/Inventory UI Toggle")]
    public class InventoryUIToggle : MonoBehaviour
    {
        [SerializeField] private GameObject _inventory;
        [SerializeField] private Animator _inventoryAnimator;

        private void Awake()
        {
            _inventory.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.InputActions.Player.OpenInventory.performed += OpenInventory;
            GameManager.Instance.InputActions.Inventory.CloseInventory.performed += CloseInventory;
        }

        private void OnDisable()
        {
            GameManager.Instance.InputActions.Player.OpenInventory.performed -= OpenInventory;
            GameManager.Instance.InputActions.Inventory.CloseInventory.performed -= CloseInventory;
        }

        private void OpenInventory(InputAction.CallbackContext callbackContext)
        {
            _inventory.SetActive(true);
            _inventoryAnimator.SetBool("IsOpen", true);
        }


        private void CloseInventory(InputAction.CallbackContext callbackContext) =>
            _inventoryAnimator.SetBool("IsOpen", false);
    }
}