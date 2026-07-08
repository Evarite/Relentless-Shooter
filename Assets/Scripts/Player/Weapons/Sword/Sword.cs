using Relentless.Player.Weapons.Base;
using System.Collections;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    /// <summary>
    /// Sword spins around the player, dealing the damage to all the targets. It's damage is reduced with every target.
    /// </summary>

    [RequireComponent(typeof(Collider2D))]
    public class Sword : Weapon
    {
        [SerializeField] private SwordData _data;
        protected override WeaponData WeaponProperties => _data;

        private Coroutine _attack;

        public override void Attack()
        {
            _attack ??= StartCoroutine(SwordSwing());
        }

        private IEnumerator SwordSwing()
        {
            //Swing logics via transform (I'm not sure if I need Rigidbody here,
            //probably I do not)
            //and using the player as the center point

            yield return new WaitForSeconds(_data.Cooldown);
            _attack = null;
        }
    }
}
