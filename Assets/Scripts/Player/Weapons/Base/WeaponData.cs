using UnityEngine;

namespace Relentless.Player.Weapons.Base
{
    public class WeaponData : ScriptableObject
    {
        [Header("Damage")]
        [SerializeField] private float _damage = 15f;

        [Header("Speed")]
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _cooldown = 0.4f;

        public float Damage { get => _damage; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Cooldown { get => _cooldown; }
    }
}
