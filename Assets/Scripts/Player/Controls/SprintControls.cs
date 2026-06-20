using Relentless.Player.StaminaSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [RequireComponent(typeof(MovementControls))]
    [RequireComponent(typeof(Stamina))]
    public class SprintControls : MonoBehaviour
    {
        private MovementControls _movementControls;
        private Stamina _stamina;

        private bool _isSprinting = false;

        [Header("Speed")]
        [SerializeField] private float _sprintSpeedMultiplier = 2f;

        public float IdleSpeedMultiplier { get; } = 1f;
        public float SprintSpeedMultiplier { get => _sprintSpeedMultiplier;
            set => _sprintSpeedMultiplier = value; }

        [Header("Stamina Consumption")]
        [Range(0.2f, 1.5f)]
        [SerializeField] private float _staminaConsumption = 1f;

        private void Awake()
        {
            _movementControls = GetComponent<MovementControls>();
            _stamina = GetComponent<Stamina>();
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
        }

        private void OnSprintEnded(InputAction.CallbackContext callbackContext) 
        {
            _isSprinting = false;
            _movementControls.SpeedMultiplier = IdleSpeedMultiplier;
        }

        private void Update()
        {
            if(_isSprinting && _movementControls.Input != Vector2.zero)
            {
                if(!_stamina.Consume(_staminaConsumption * Time.deltaTime))
                {
                    _isSprinting = false;
                    _movementControls.SpeedMultiplier = IdleSpeedMultiplier;
                }
            }
        }
    }
}