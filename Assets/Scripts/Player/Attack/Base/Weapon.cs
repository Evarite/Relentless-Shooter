using UnityEngine;

namespace Relentless.Player.Attack.Base
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected abstract WeaponData WeaponProperties { get; }

        public abstract void Attack();
    }
}
