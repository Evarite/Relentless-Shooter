using Relentless.Player.Attack.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [AddComponentMenu("Relentless/Player/Controls/Attack Controls")]
    public class AttackControls : MonoBehaviour
    {
        //TODO
        //Remove serialize field with the possibility of changing the weapon on runtime
        [SerializeField] private IWeapon _weapon;

        private void OnEnable()
        {
            GameManager.InputActions.Player.Attack.performed += Attack;
        }

        private void OnDisable()
        {
            GameManager.InputActions.Player.Attack.performed -= Attack;
        }

        private void Attack(InputAction.CallbackContext callbackContext)
        {
            _weapon.Attack();
        }
    }
}
