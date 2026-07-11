using Relentless.HealthSystem;
using Relentless.Player.Weapons.Base;
using System.Collections;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    /// <summary>
    /// Sword spins around the player, dealing the damage to all the targets. It's damage is reduced with every target.
    /// </summary>
 
    [RequireComponent(typeof(SwordSwing))]
    public class Sword : Weapon
    {
        [SerializeField] private SwordData _data;
        protected override WeaponData WeaponProperties => _data;

        private SwordSwing _swing;

        private void Awake()
        {
            _swing = GetComponent<SwordSwing>();
            gameObject.SetActive(false);
        }

        private void OnEnable() => SwordDamage.RegisterCurrentSword(_data);

        public override void Attack(Vector2 direction)
        {
            gameObject.SetActive(true);
            _swing.Attack(direction, _data);
        }

        protected override void DealDamage(IHittable hittable) =>
            SwordDamage.DealDamage(hittable);
    }
}