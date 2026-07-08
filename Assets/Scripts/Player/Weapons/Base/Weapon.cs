using Relentless.Player.Attack.Base;
using UnityEngine;

namespace Relentless.Player.Weapons.Base
{
    [AddComponentMenu("Relentless/Player/Attack/Base/Weapon")]
    public abstract class Weapon : MonoBehaviour, IWeapon
    { 
        protected abstract WeaponData WeaponProperties { get; }

        public abstract void Attack();
    }
}
