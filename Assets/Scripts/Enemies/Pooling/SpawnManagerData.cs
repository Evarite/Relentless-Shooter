using Relentless.Utilities.Probability;
using UnityEngine;

namespace Relentless.Pooling
{
    [System.Serializable]
    public class SpawnManagerData
    {
        [Header("Enemy Kinds")]
        [SerializeField] private ProbabilityList<PoolManager> _enemyPools;

        [Header("Spawn Settings")]
        [SerializeField] private int _maxEnemiesCount = 50;
        [SerializeField] private float _spawnInterval = 1f;
        [Tooltip("How far away from the player an enemy will be spawned")]
        [SerializeField] private float _spawnDistance = 30f;

        [Header("Despawn Settings")]
        [SerializeField] private float _maxDistance = 100f;
        [SerializeField] private float _despawnInterval = 5f;

        public ProbabilityList<PoolManager> EnemyPools { get => _enemyPools; }
        public int MaxEnemiesCount { get => _maxEnemiesCount; set => _maxEnemiesCount = value; }
        public float SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }
        public float SpawnDistance { get => _spawnDistance; set => _spawnDistance = value; }
        public float MaxDistance { get => _maxDistance; set => _maxDistance = value; }
        public float DespawnInterval { get => _despawnInterval; set => _despawnInterval = value; }
    }
}
