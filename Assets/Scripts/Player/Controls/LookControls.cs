using Relentless.CameraSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Relentless.Player.Controls
{
    public class LookControls : MonoBehaviour   
    {
        [Header("Camera script")]
        [SerializeField] private CameraFollow _cameraFollow;

        [Header("Limitations")]
        [SerializeField] private float _maxDistance;
        //[SerializeField] private float _speed;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 cursorScreenPosition = Mouse.current.position.ReadValue();
            cursorScreenPosition.z = _camera.nearClipPlane;
            Vector3 cursorWorldPos = _camera.ScreenToWorldPoint(cursorScreenPosition);

            Vector3 offset = _camera.transform.position - cursorWorldPos;
            offset = Vector3.ClampMagnitude(offset, _maxDistance);
            _cameraFollow.CameraOffset = offset;
        }
    }
}
