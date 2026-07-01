using Relentless;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryControls : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject HUD;

    private bool _isOpen = false;

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