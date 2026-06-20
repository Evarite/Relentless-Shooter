using Relentless.Player.Attack.Base;
using UnityEngine;

namespace Relentless.Player.Attack.Sword
{
    [CreateAssetMenu(fileName = "Sword Data", menuName = "Relentless/Player/Attack/Sword")]
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
}}
