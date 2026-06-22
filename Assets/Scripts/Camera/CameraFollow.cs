using UnityEngine;

namespace Relentless.CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _smoothTime = 0.2f;

        //Offset of the player Look controls
        public Vector2 CameraOffset { get; set; } = Vector2.zero;

        private Transform _playerTransform;
        private Vector3 _currentVelocity;

        private float _zOffset = 3f;

        private void OnEnable()
        {
            if(GameManager.Player != null)
                GetPlayerTransform();
        }

        private void LateUpdate()
        {
            if(_playerTransform == null)
            {
                GetPlayerTransform();
                if (_playerTransform == null)
                    return;
            }

            Vector3 playerPos = _playerTransform.position;
            Vector3 targetPosition = new Vector3(
                playerPos.x + CameraOffset.x,
                playerPos.y + CameraOffset.y,
                _zOffset
                );

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                ref _currentVelocity, _smoothTime);
        }

        private void GetPlayerTransform()
        {
            if (GameManager.Player != null)
                _playerTransform = GameManager.Player.transform;
        }
    }
}