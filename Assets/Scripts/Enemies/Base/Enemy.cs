using UnityEngine;
using Relentless.HealthSystem;
using Relentless.Enemies.Base.Data;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        public EnemyData Data { get => _enemyData;}
    }
}