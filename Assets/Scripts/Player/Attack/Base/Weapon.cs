using UnityEngine;

namespace Relentless.Player.Attack.Base
{
    [AddComponentMenu("Relentless/Player/Attack/Base/Weapon")]
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected abstract WeaponData WeaponProperties { get; }

        public abstract void Attack();
    }
}
