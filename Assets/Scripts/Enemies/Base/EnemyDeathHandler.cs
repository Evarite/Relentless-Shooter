using Relentless.HealthSystem;
using Relentless.Pooling;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(PooledEntity))]
    public class EnemyDeathHandler : MonoBehaviour, IDeathHandler
    {
        private PooledEntity _pe;

        private void Awake() => _pe = GetComponent<PooledEntity>();

        public void Die()
        {
            _pe.Return();
        }
    }
}
