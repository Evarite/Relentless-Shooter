using Relentless.HealthSystem;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    public class EnemyDeathHandler : MonoBehaviour, IDeathHandler
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
