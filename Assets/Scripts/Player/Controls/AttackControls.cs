using Relentless.Managers;
using Relentless.Player.Weapons.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [AddComponentMenu("Relentless/Player/Controls/Attack Controls")]
    public class AttackControls : MonoBehaviour
    {
        //TODO
        //Remove serialize field with the possibility of changing the weapon on runtime
        [SerializeField] private Weapon _weapon;

        private void OnEnable()
        {
            GameManager.Instance.InputActions.Player.Attack.performed += Attack;
        }

        private void OnDisable()
        {
            GameManager.Instance.InputActions.Player.Attack.performed -= Attack;
        }

        private void Attack(InputAction.CallbackContext callbackContext)
        {
            Vector2 rawInput = GameManager.Instance.InputActions.Player.Look.ReadValue<Vector2>();
            var device = GameManager.Instance.InputActions.Player.Look.activeControl?.device;

            Vector2 direction = Vector2.zero;

            if (device is Mouse)
            {
                Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
                direction = (rawInput - screenCenter).normalized;
            }
            else if (device is Gamepad)
            {
                direction = rawInput.normalized;
            }

            _weapon.Attack(direction);
        }
    }
}
