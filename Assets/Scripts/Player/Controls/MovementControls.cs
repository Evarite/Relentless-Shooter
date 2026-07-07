using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    [AddComponentMenu("Relentless/Player/Controls/Movement Controls")]
    public class MovementControls : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float SpeedMultiplier { get; set; } = 1f;

        private Rigidbody2D _rb;

        public Vector2 Input { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            GameManager.InputActions.Player.Move.performed += OnMovementChanged;
            GameManager.InputActions.Player.Move.canceled += OnMovementChanged;
        }

        private void OnDisable()
        {
            GameManager.InputActions.Player.Move.performed -= OnMovementChanged;
            GameManager.InputActions.Player.Move.canceled -= OnMovementChanged;
        }

        private void OnMovementChanged(InputAction.CallbackContext callbackContext)
        {
            Input = callbackContext.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = Input * _speed * SpeedMultiplier;
        }
    }
}