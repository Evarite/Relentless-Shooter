using UnityEngine;
using System.Collections;
using Relentless.Player.Weapons.Base;

namespace Relentless.Player.Weapons.Axe
{
    /// <summary>
    /// Axe swings in a limited angle, dealing high damage to all the targets within it.
    /// </summary>

    [RequireComponent(typeof(AxeSwing))]
    public class Axe : Weapon
    {
        [SerializeField] private AxeData _data; 
        protected override WeaponData WeaponProperties => _data;

        private AxeSwing _swing;

        private void Awake()
        {
            _swing = GetComponent<AxeSwing>();
            gameObject.SetActive(false);
        }

        public override void Attack(Vector2 direction)
        {
            gameObject.SetActive(true);
            _swing.Attack(direction, _data);
        }
    }
}
