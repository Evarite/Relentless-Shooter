using Relentless.Utilities;
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
            Quaternion startRotation = SetInitialPosition(direction, data);

            float elapsed = 0f;

            while(elapsed < data.AttackDuration)
            {
                float t = elapsed / data.AttackDuration;
                float easedT = Easings.EeaseInBackOutQuart(t);

                float currentAngle = data.MaxSwingAngle * easedT;
                Quaternion delta = Quaternion.AngleAxis(-currentAngle, _rotationAxis);

                transform.rotation = delta * startRotation;
                transform.localPosition = (Vector3)_pivotPoint + (transform.rotation * _pivotOffset);

                elapsed += Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(data.AttackDuration);

            _attack = null;
            gameObject.SetActive(false);
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
