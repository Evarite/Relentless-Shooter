using UnityEngine;

namespace Relentless.Player.Weapons.Base
{
    public class WeaponData : ScriptableObject
    {
        [Header("Damage")]
        [Tooltip("The damage dealt by the weapon")]
        [SerializeField] private float _damage = 15f;

        [Header("Speed")]
        [Tooltip("Time in seconds to perform a full attack")]
        [SerializeField] private float _attackDuration = 1f;
        [Tooltip("Time in seconds between attacks")]
        [SerializeField] private float _cooldown = 0.4f;

        public float Damage { get => _damage; }
        public float AttackDuration { get => _attackDuration; }
        public float Cooldown { get => _cooldown; }
    }
}
