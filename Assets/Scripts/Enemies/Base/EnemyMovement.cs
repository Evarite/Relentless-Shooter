using Relentless.Enemies.Base.Data;
using Relentless.Managers;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyData _enemyData;
        private Rigidbody2D _rb;

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void Start()
        {
            Enemy enemy = GetComponent<Enemy>();
            _enemyData = enemy.Data;
        }

        private void OnDisable() => _rb.linearVelocity = Vector2.zero;

        private void FixedUpdate()
        {
            if (GameManager.Instance.Player == null)
                return;

            Vector2 playerPos = GameManager.Instance.Player.transform.position;
            Vector2 dif = playerPos - (Vector2)transform.position;
            if (dif.sqrMagnitude <= _enemyData.StopThreshold * _enemyData.StopThreshold)
            {
                _rb.linearVelocity = Vector2.zero;
                return;
            }

            Vector2 direction = dif.normalized;
            _rb.linearVelocity = direction * _enemyData.Speed;
        }
    }
}