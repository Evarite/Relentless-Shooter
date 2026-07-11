using System.Collections;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    public class SwordSwing : MonoBehaviour
    {
        private Coroutine _attack = null;

        private float _rotationDegrees = 360f;
        private Vector2 _pivotPoint = Vector2.zero;
        private Vector3 _rotationAxis = Vector3.forward;
        private Vector2 _pivotOffset;

        public void Attack(Vector2 direction, SwordData data)
        {
            _attack ??= StartCoroutine(Swing(direction, data));
        }

        private void Awake() => _pivotOffset = transform.position;

        private void OnDisable()
        {
            if (_attack != null)
            {
                StopCoroutine(_attack);
                _attack = null;
            }
        }

        private IEnumerator Swing(Vector2 direction, SwordData data)
        {
            Quaternion startRotation = SetInitialPosition(direction);

            float totalAngle = data.Rotations * _rotationDegrees;
            float elapsed = 0f;

            while (elapsed < data.AttackDuration)
            {
                float t = elapsed / data.AttackDuration;
                float easedT = EaseInOut(t);

                float currentAngle = totalAngle * easedT;

                Quaternion delta = Quaternion.AngleAxis(currentAngle, _rotationAxis);

                transform.rotation = startRotation * delta;

                transform.localPosition = (Vector3)_pivotPoint + (transform.rotation * _pivotOffset);

                elapsed += Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(data.Cooldown);

            _attack = null;
            gameObject.SetActive(false);
        }

        private Quaternion SetInitialPosition(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            transform.rotation = rotation;

            transform.localPosition = (Vector3)_pivotPoint + (rotation * _pivotOffset);

            return rotation;
        }

        private float EaseInOut(float x) => -1 * (Mathf.Cos(Mathf.PI * x) - 1) / 2;
    }
}
