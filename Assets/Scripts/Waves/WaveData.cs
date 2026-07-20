using UnityEngine;

namespace Relentless.Waves
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Relentless/Waves/Wave Data")]
    public class WaveData : ScriptableObject
    {
        //TODO
        //Add a list of current enemies

        [Header("Wave Cycle")]
        [SerializeField] private float _waveCycleTime = 120f;

        [Header("Modifiers")]
        [SerializeField] private float _damageModifier = 1f;
        [SerializeField] private float _healthModifier = 1f;
        [SerializeField] private float _speedModifier = 1f;

        public float WaveCycleTime { get => _waveCycleTime; set => _waveCycleTime = value; }
        public float DamageModifier { get => _damageModifier; set => _damageModifier = value; }
        public float HealthModifier { get => _healthModifier; set => _healthModifier = value; }
        public float SpeedModifier { get => _speedModifier; set => _speedModifier = value; }
    }
}