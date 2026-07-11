using Relentless.HealthSystem;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    public static class SwordDamage
    {
        private static SwordData _data;
        private static float _currentDamage;

        public static void RegisterCurrentSword(SwordData data)
        {
            _data = data;
            _currentDamage = data.Damage;
        }

        public static void DealDamage(IHittable hittable)
        {
            hittable.React(_currentDamage);
            Debug.Log(_currentDamage);
            _currentDamage = Mathf.Max(0, _currentDamage - _data.DamageReduction);
        }
    }
}