using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Waves
{
    [RequireComponent(typeof(WaveTimer))]
    public class WaveBuffing : MonoBehaviour
    {
        [Header("Buff Iterations")]
        [Min(1)]
        [SerializeField] private int _buffIterations = 1;

        [SerializeField] private WaveEnemiesBuffData _buffData;

        private List<BuffOption> _buffs = new List<BuffOption>();

        private WaveTimer _timer;

        private void Awake()
        {
            _timer = GetComponent<WaveTimer>();

            _buffs.Add(new BuffOption
                (
                _buffData.HealthBuffWeight,
                () => { BuffsModifiers.HealthBuffModifier += _buffData.BuffStep; }
                ));

            _buffs.Add(new BuffOption
                (
                _buffData.DamageBuffWeight,
                () => { BuffsModifiers.DamageBuffModifier += _buffData.BuffStep; }
                ));

            _buffs.Add(new BuffOption
                (
                _buffData.SpeedBuffWeight,
                () => { BuffsModifiers.SpeedBuffModifier += _buffData.BuffStep; }
                ));

            _buffs.Add(new BuffOption
                (
                _buffData.IterationBuffWeight,
                () => { _buffIterations += _buffData.IterationStep; }
                ));

            _buffs.Add(new BuffOption
                (
                _buffData.EmptyWeight,
                () => { }
                ));
        }

        private void OnEnable() => _timer.OnTimeRanOut += Buff;

        private void OnDisable() => _timer.OnTimeRanOut -= Buff;

        private void Buff()
        {
            for (int i = 0; i <= _buffIterations; i++)
            {
                float weight = Random.Range(0f, _buffData.TotalWeight);
                float currentWeight = 0f;

                foreach (var buff in _buffs)
                {
                    currentWeight += buff.Weight;
                    if (weight <= currentWeight)
                    {
                        buff.Buff?.Invoke();
                        break;
                    }
                }
            }
        }

        private class BuffOption
        {
            private float _weight;
            private System.Action _buff;

            public BuffOption(float Weight, System.Action Buff)
            {
                _weight = Weight;
                _buff = Buff;
            }

            public float Weight { get => _weight; }
            public System.Action Buff { get => _buff; }
        }
    }
}