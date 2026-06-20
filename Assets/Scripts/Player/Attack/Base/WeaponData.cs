using UnityEngine;

namespace Relentless.Player.Attack.Base
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Relentless/Player/Attack/Base/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [Header("Damage")]
        [SerializeField] private float _damage = 15f;

        [Header("Speed")]
        [SerializeField] private float _preparationTime = 0.1f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _cooldown = 0.4f;

        public float Damage { get => _damage; }
        public float PreparationTime { get => _preparationTime; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Cooldown { get => _cooldown; }
    }
}
