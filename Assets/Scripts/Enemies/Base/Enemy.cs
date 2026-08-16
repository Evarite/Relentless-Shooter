using Relentless.Enemies.Base.Data;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(EnemyHealth))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        public EnemyData Data { get => _enemyData; }
    }
}