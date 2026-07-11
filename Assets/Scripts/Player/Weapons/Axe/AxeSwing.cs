using System.Collections;
using UnityEngine;

namespace Relentless.Player.Weapons.Axe
{
    public class AxeSwing : MonoBehaviour
    {
        private Coroutine _attack = null;

        private Vector2 _pivotPoint = Vector2.zero;
        private Vector2 _pivotOffset;
        private Vector3 _rotationAxis = Vector3.forward;

        private void Awake() => _pivotOffset = transform.localPosition;

        private void OnDisable()
        {
            if (_attack != null)
            {
                StopCoroutine(_attack);
                _attack = null;
            }
        }

        public void Attack(Vector2 direction, AxeData data) =>
            _attack ??= StartCoroutine(Swing(direction, data));

        private IEnumerator Swing(Vector2 direction, AxeData data)
        {
            SetInitialPosition(direction, data);


        }

        private Quaternion SetInitialPosition(Vector2 direction, AxeData data)
        {
            float dirAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float startAngle = dirAngle + data.MaxSwingAngle / 2; //+ will set it counterclockwise

            Quaternion initialRotation = Quaternion.AngleAxis(startAngle, _rotationAxis);
            transform.rotation = initialRotation;

            transform.localPosition = (Vector3)_pivotPoint + (transform.rotation * _pivotOffset);

            return initialRotation;
        }
    }
}
