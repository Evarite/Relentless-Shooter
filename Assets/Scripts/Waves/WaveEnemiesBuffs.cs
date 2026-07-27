using UnityEngine;

namespace Relentless.Waves
{
    public class WaveEnemiesBuffs : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private WaveData _data;
        [SerializeField] private WaveTimer _timer;

        [Header("Buff Iterations")]
        [Min(1)]
        [SerializeField] private int _buffIterations = 1;

        [Header("Buffs Probabilities")]
        [SerializeField] private float _healthBuffWeight;
        [SerializeField] private float _damageBuffWeight;
        [SerializeField] private float _speedBuffWeight;
        [SerializeField] private float _iterationsIncreaseWeight;
        [SerializeField] private float _emptyWeight;

        private void OnEnable() => _timer.OnTimeRanOut += Buff;

        private void OnDisable() => _timer.OnTimeRanOut -= Buff;

        private void Buff()
        {

        }
    }
}
