using Relentless.Utilities.WeightedRandom;
using System;
using UnityEngine;

namespace Relentless.Waves
{
    [CreateAssetMenu(fileName = "Wave Buffs Data", menuName = "Relentless/Waves/Buffs Data")]
    public class WaveEnemiesBuffData : ScriptableObject
    {
        [Header("Buff Iterations")]
        [Min(1)]
        [SerializeField] private int _buffIterations = 1;

        [Header("Buffs")]
        [SerializeField] private WeightedRandomList<Action> _buffs;
    }
}
