using Relentless.Player.Attack.Base;
using System.Collections;
using UnityEngine;

namespace Relentless.Player.Attack.Sword
{
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
            yield return new WaitForSeconds(_data.PreparationTime);

            //Swing logics via transform (I'm not sure if I need Rigidbody here, probably I do not)
            //and using the player as the center point

            yield return new WaitForSeconds(_data.Cooldown);
            _attack = null;
        }
    }
}
