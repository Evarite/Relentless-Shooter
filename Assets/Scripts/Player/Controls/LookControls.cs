using Relentless.CameraSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    [AddComponentMenu("Relentless/Player/Controls/Look Controls")]
    public class LookControls : MonoBehaviour
    {
        [Header("Camera script")]
        [SerializeField] private CameraFollow _cameraFollow;

        [Header("Limitations")]
        [Range(1f, 10f)]
        [SerializeField] private float _maxDistance = 3f;

        [Header("Gamepad reset")]
        [SerializeField] private float _resetTime = 1f;
        private Vector2 _currentSpeed = Vector2.zero;

        private Camera _camera;

        //Used for attacking. The attack will be performed in the direction. If the direction is zero
        //The attack will be performed in the direction of the closest enemy.
        private Vector2 _normalizedOffset;
        public Vector2 NormalizedPosition { get => _normalizedOffset; }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector2 rawInput = GameManager.InputActions.Player.Look.ReadValue<Vector2>();
            _normalizedOffset = Vector2.zero;

            var device = GameManager.InputActions.Player.Look.activeControl?.device;

            if (device is Mouse)
            {
                Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
                _normalizedOffset = rawInput - screenCenter;

                _normalizedOffset.x /= Screen.width * 0.5f;
                _normalizedOffset.y /= Screen.height * 0.5f;
            }
            else if (device is Gamepad || device ==null )
            {
                _normalizedOffset = rawInput;
            }
            else
            {
                _normalizedOffset = Vector2.zero;
                return;
            }

            Vector2 targetOffset = _normalizedOffset * _maxDistance;

            if (device is Gamepad || device == null)
            {
                _cameraFollow.CameraOffset = Vector2.SmoothDamp(
                    _cameraFollow.CameraOffset,
                    targetOffset,
                    ref _currentSpeed,
                    _resetTime);
            }
            else
            {
                _cameraFollow.CameraOffset = targetOffset;
            }
        }
    }
}