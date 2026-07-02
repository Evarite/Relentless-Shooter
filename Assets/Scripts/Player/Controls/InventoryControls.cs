using Relentless;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [AddComponentMenu("Relentless/Player/Controls/Inventory Controls")]
    public class InventoryControls : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManager.InputActions.Player.OpenInventory.performed += OpenInventory;
            GameManager.InputActions.Inventory.CloseInventory.performed += CloseInventory;
        }

        private void OnDisable()
        {
            GameManager.InputActions.Player.OpenInventory.performed -= OpenInventory;
            GameManager.InputActions.Inventory.CloseInventory.performed -= CloseInventory;
        }

        private void OpenInventory(InputAction.CallbackContext callbackContext) =>
            GameManager.ActivateInventory();

        private void CloseInventory(InputAction.CallbackContext callbackContext) =>
            GameManager.ActivatePlayer();
    }
}