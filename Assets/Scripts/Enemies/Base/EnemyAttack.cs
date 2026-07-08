using Relentless.HealthSystem;
using System.Collections;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Collider2D))]
    public class EnemyAttack : MonoBehaviour
    {
        protected EnemyData _enemyData;
        protected Health playerHealth;
        protected Coroutine attack;

        protected WaitForSeconds attackCooldown;

        protected string playerTag = "Player";

        protected virtual void Awake()
        {
            _enemyData = GetComponent<Enemy>().Data;
            attackCooldown = new WaitForSeconds(_enemyData.AttackCooldown);
        }

        protected virtual IEnumerator Attack()
        {
            Debug.Log("Attack started");

            while (GameManager.Player != null)
            {
                playerHealth.React(_enemyData.Damage);
                yield return new WaitForSeconds(_enemyData.AttackCooldown);
            }

            attack = null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Trigger collision detected");

            if (!collision.CompareTag(playerTag))
                return;

            if (playerHealth == null && GameManager.Player != null)
                playerHealth = GameManager.Player.GetComponent<Health>();

            if (playerHealth == null)
                return;

            if (attack == null)
                attack = StartCoroutine(Attack());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag(playerTag))
                return;

            if (attack != null)
            {
                StopCoroutine(attack);
                attack = null;
            }
        }

        private void OnDisable()
        {
            if (attack != null)
            {
                StopCoroutine(attack);
                attack = null;
            }
        }
    }
}