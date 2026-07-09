using Relentless.Player.Weapons.Base;
using System.Collections;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    /// <summary>
    /// Sword spins around the player, dealing the damage to all the targets. It's damage is reduced with every target.
    /// </summary>

    [RequireComponent(typeof(Collider2D))]
    public class SwordSwing : Weapon
    {
        [SerializeField] private SwordData _data;
        protected override WeaponData WeaponProperties => _data;

        private Coroutine _attack;

        private Vector2 _pivotPoint = Vector2.zero;
        private Vector3 _rotationAxis = Vector3.forward;
        private Vector2 _pivotOffset;
        private float _rotationDegrees = 360f;

        private void Awake()
        {
            _pivotOffset = transform.position;
            gameObject.SetActive(false);
        }

        public override void Attack(Vector2 direction)
        {
            gameObject.SetActive(true);
            _attack ??= StartCoroutine(Swing(direction));
        }

        private IEnumerator Swing(Vector2 direction)
        {
            Quaternion startRotation = SetInitialPosition(direction);

            float totalAngle = _data.Rotations * _rotationDegrees;
            float elapsed = 0f;

            while (elapsed < _data.AttackDuration)
            {
                float t = elapsed / _data.AttackDuration;
                float easedT = EaseInOut(t);

                float currentAngle = totalAngle * easedT;

                Quaternion delta = Quaternion.AngleAxis(currentAngle, _rotationAxis);

                transform.rotation = startRotation * delta;

                transform.localPosition = (Vector3)_pivotPoint + (transform.rotation * _pivotOffset);

                elapsed += Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(_data.Cooldown);
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