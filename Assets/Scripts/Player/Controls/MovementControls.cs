using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementControls : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float SpeedMultiplier { get; set; } = 1f;

        private Rigidbody2D _rb;

        private Vector2 _input;

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
            _input = callbackContext.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _input * _speed * SpeedMultiplier;
        }
    }
}