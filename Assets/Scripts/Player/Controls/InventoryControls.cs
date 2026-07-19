using Relentless.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [AddComponentMenu("Relentless/Player/Controls/Inventory Controls")]
    public class InventoryControls : MonoBehaviour
    {
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

        private void OpenInventory(InputAction.CallbackContext callbackContext) =>
            GameManager.Instance.ActivateInventory();

        private void CloseInventory(InputAction.CallbackContext callbackContext) =>
            GameManager.Instance.ActivatePlayer();
    }
}