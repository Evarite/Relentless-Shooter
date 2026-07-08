using UnityEngine;
using Relentless.HealthSystem;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy Data")]
        [SerializeField] private EnemyData _enemyData;

        private SpriteRenderer _spriteRenderer;

        public EnemyData Data 
        { 
            get => _enemyData;
            set 
            { 
                _enemyData = value;
                _spriteRenderer.sprite = _enemyData.Sprite;
            }
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _enemyData.Sprite;
        }
    }
}