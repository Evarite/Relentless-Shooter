using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [RequireComponent(typeof(MovementControls))]
    public class SprintControls : MonoBehaviour
    {
        private MovementControls _movementControls;

        private bool _isSprinting = false;

        [SerializeField] private float _idleSpeedMultiplier = 1f;
        [SerializeField] private float _sprintSpeedMultiplier = 2f;

        public float IdleSpeedMultiplier { get => _idleSpeedMultiplier;
            set => _idleSpeedMultiplier = value; }
        public float SprintSpeedMultiplier { get => _sprintSpeedMultiplier;
            set => _sprintSpeedMultiplier = value; }

        private void Awake()
        {
            _movementControls = GetComponent<MovementControls>();
        }

        private void OnEnable()
        {
            GameManager.InputActions.Player.Sprint.performed += OnSprintStarted;
            GameManager.InputActions.Player.Sprint.canceled += OnSprintEnded;
        }

        private void OnDisable()
        {
            GameManager.InputActions.Player.Sprint.performed -= OnSprintStarted;
            GameManager.InputActions.Player.Sprint.canceled -= OnSprintEnded;
        }

        private void OnSprintStarted(InputAction.CallbackContext callbackContext)
        {
            _isSprinting = true;
            _movementControls.SpeedMultiplier = SprintSpeedMultiplier;
        }

        private void OnSprintEnded(InputAction.CallbackContext callbackContext) 
        {
            _isSprinting = false;
            _movementControls.SpeedMultiplier = IdleSpeedMultiplier;
        }
    }
}