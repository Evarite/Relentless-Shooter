using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyData _enemyData;

        private void Start()
        {
            Enemy enemy = GetComponent<Enemy>();
            _enemyData = enemy.Data;
        }

        private void Update()
        {
            if (GameManager.Player == null)
                return;

            Vector3 playerPos = GameManager.Player.transform.position;
            Vector2 dif = playerPos - transform.position;
            if(dif.magnitude <= _enemyData.StopThreshold)
                return;

            Vector2 direction = dif.normalized;
            transform.position += (Vector3)direction * _enemyData.Speed * Time.deltaTime;
        }
    }
}