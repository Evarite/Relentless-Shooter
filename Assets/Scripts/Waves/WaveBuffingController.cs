using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Relentless.Waves
{
    [RequireComponent(typeof(WaveTimer))]
    public class WaveBuffingController : MonoBehaviour
    {
        private int _buffIterations;

        [SerializeField] private WaveEnemiesBuffData _buffData;

        private List<BuffOption> _buffOptions = new List<BuffOption>();

        private WaveTimer _timer;

        private Dictionary<string, float> _buffs = new()
        { { "Health", 0f }, { "Damage", 0f }, { "Speed", 0f } };

        public event System.Action<Dictionary<string, float>> OnBuffed;

        private void Awake()
        {
            _timer = GetComponent<WaveTimer>();

            _buffIterations = _buffData.BuffIterations;

            _buffOptions.Add(new BuffOption
                (
                _buffData.HealthBuffWeight,
                () =>
                {
                    BuffsModifiers.HealthBuffModifier += _buffData.BuffStep;
                    _buffs["Health"] += _buffData.BuffStep;
                }
                ));

            _buffOptions.Add(new BuffOption
                (
                _buffData.DamageBuffWeight,
                () =>
                {
                    BuffsModifiers.DamageBuffModifier += _buffData.BuffStep;
                    _buffs["Damage"] += _buffData.BuffStep;
                }
                ));

            _buffOptions.Add(new BuffOption
                (
                _buffData.SpeedBuffWeight,
                () =>
                {
                    BuffsModifiers.SpeedBuffModifier += _buffData.BuffStep;
                    _buffs["Speed"] += _buffData.BuffStep;
                }
                ));

            _buffOptions.Add(new BuffOption
                (
                _buffData.IterationBuffWeight,
                () => { _buffIterations += _buffData.IterationStep; }
                ));

            _buffOptions.Add(new BuffOption
                (
                _buffData.EmptyWeight,
                () => { }
                ));
        }

        private void OnEnable() => _timer.OnTimeRanOut += Buff;

        private void OnDisable() => _timer.OnTimeRanOut -= Buff;

        private void Buff()
        {
            foreach (var buff in _buffs.Keys.ToArray())
                _buffs[buff] = 0;

            for (int i = 0; i < _buffIterations; i++)
            {
                float weight = Random.Range(0f, _buffData.TotalWeight);
                float currentWeight = 0f;

                foreach (var buff in _buffOptions)
                {
                    currentWeight += buff.Weight;
                    if (weight <= currentWeight)
                    {
                        buff.Buff?.Invoke();
                        break;
                    }
                }
            }

            OnBuffed?.Invoke(_buffs);
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