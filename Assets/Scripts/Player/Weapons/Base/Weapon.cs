using Relentless.HealthSystem;
using Relentless.Player.Attack.Base;
using UnityEngine;

namespace Relentless.Player.Weapons.Base
{
    [AddComponentMenu("Relentless/Player/Attack/Base/Weapon")]
    [RequireComponent(typeof(Collider2D))]
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected abstract WeaponData WeaponProperties { get; }

        public abstract void Attack(Vector2 direction);

        protected virtual void DealDamage(IHittable hittable)
        {
            hittable.React(WeaponProperties.Damage);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collider) //Works only on Enemies layer
        {
            if (collider.TryGetComponent(out IHittable hittable))
                DealDamage(hittable);
        }
    }
}
