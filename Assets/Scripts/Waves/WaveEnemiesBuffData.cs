using UnityEngine;

namespace Relentless.Waves
{
    [CreateAssetMenu(fileName = "Wave Buffs Data", menuName = "Relentless/Waves/Buffs Data")]
    public class WaveEnemiesBuffData : ScriptableObject
    {
        [Header("Buff Iterations")]
        [Min(1)]
        [SerializeField] private int _buffIterations = 1;

        [Header("Buffs Weight")]
        [SerializeField] private float _speedBuffWeight = 2f;
        [SerializeField] private float _healthBuffWeight = 3f;
        [SerializeField] private float _damageBuffWeight = 5f;
        [SerializeField] private float _iterationBuffWeight = 0.5f;
        [SerializeField] private float _emptyWeight = 1f;
        private float _totalWeight = 0f;

        [Header("Buffs Step")]
        [SerializeField] private float _buffStep = 0.05f;
        [SerializeField] private int _iterationStep = 1;

        private void Awake() =>
            _totalWeight = _speedBuffWeight + _healthBuffWeight + _damageBuffWeight + _emptyWeight;

        public float SpeedBuffWeight { get => _speedBuffWeight; }
        public float HealthBuffWeight { get => _healthBuffWeight; }
        public float DamageBuffWeight { get => _damageBuffWeight; }
        public float EmptyWeight { get => _emptyWeight; }
        public float BuffStep { get => _buffStep; }
        public float TotalWeight { get => _totalWeight; }
        public float IterationBuffWeight { get => _iterationBuffWeight; }
        public int IterationStep { get => _iterationStep; }
        public int BuffIterations { get => _buffIterations; set => _buffIterations = value; }
    }
}