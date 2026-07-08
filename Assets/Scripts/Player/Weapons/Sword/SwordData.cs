using Relentless.Player.Weapons.Base;
using UnityEngine;

namespace Relentless.Player.Weapons.Sword
{
    [CreateAssetMenu(fileName = "New Sword", menuName = "Relentless/Weapons/Sword Data")]
    public class SwordData : WeaponData
    {
        [Header("Sword")]
        [Tooltip("The amount of rotations to be performed. Float values mean the last rotation will not" +
            " be fully complete.")]
        [SerializeField] private float _rotations = 1f;

        [Tooltip("Per each enemy the sword hits, the damage gets reduced by this value.")]
        [SerializeField] private float _damageReduction = 3f;

        public float Rotations { get => _rotations; }
        public float DamageReduction { get => _damageReduction; }
    }
}
