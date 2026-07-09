using UnityEngine;
using System.Collections;
using Relentless.Player.Weapons.Base;

namespace Relentless.Player.Weapons.Axe
{
    /// <summary>
    /// Axe swings in a limited angle, dealing high damage to all the targets within it.
    /// </summary>
    public class Axe : Weapon
    {
        [SerializeField] private AxeData _data; 
        protected override WeaponData WeaponProperties => _data;

        private Coroutine _attack;

        public override void Attack(Vector2 direction)
        {
            _attack ??= StartCoroutine(AxeSwing(direction));
        }

        private IEnumerator AxeSwing(Vector2 direction)
        {
            //Swing logics

            yield return new WaitForSeconds(_data.Cooldown);
        }
    }
}
