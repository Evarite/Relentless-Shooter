using Relentless.HealthSystem;
using Relentless.Pooling;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(PooledEntity))]
    [RequireComponent(typeof(Enemy))]
    public class EnemyDeathHandler : MonoBehaviour, IDeathHandler
    {
        private EnemyData _enemyData;
        private PooledEntity _pe;

        private void Awake()
        {
            _pe = GetComponent<PooledEntity>();
            _enemyData = GetComponent<Enemy>().Data;
        }

        public void Die()
        {
            EnemyItemDrop.SpawnItem(_enemyData);
            _pe.Return();
        }
    }
}
