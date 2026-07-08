using UnityEngine;
using Relentless.HealthSystem;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        public EnemyData EnemyData { get => _enemyData;}
    }
}