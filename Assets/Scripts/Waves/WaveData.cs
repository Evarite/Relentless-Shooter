using Relentless.Pooling;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Waves
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Relentless/Waves/Wave Data")]
    public class WaveData : ScriptableObject
    {
        //TODO
        //Add a list of current enemies
        [Header("Enemies")]
        [SerializeField] private List<ObjectPool> _enemyPools;
        private List<ObjectPool> _activePools;

        [Header("Wave Cycle")]
        [SerializeField] private float _waveCycleTime = 120f;

        public float WaveCycleTime { get => _waveCycleTime; set => _waveCycleTime = value; }
    }
}