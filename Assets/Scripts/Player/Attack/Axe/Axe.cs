using UnityEngine;
using Relentless.Player.Attack.Base;
using System.Collections;

namespace Relentless.Player.Attack.Axe
{
    /// <summary>
    /// Axe swings in a limited angle, dealing high damage to all the targets within it.
    /// </summary>
    public class Axe : Weapon
    {
        [SerializeField] private AxeData _data; 
        protected override WeaponData WeaponProperties => _data;

        private Coroutine _attack;

        public override void Attack()
        {
            _attack ??= StartCoroutine(AxeSwing());
        }

        private IEnumerator AxeSwing()
        {
            yield return new WaitForSeconds(_data.PreparationTime);

            //Swing logics

            yield return new WaitForSeconds(_data.Cooldown);
        }
    }
}
