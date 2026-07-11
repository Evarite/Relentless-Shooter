using Relentless.HealthSystem;
using System.Collections;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Collider2D))]
    public class EnemyAttack : MonoBehaviour
    {
        protected EnemyData enemyData;
        protected Health playerHealth;
        protected Coroutine attack;

        protected string playerTag = "Player";

        private WaitUntil _untilAttackPossible;
        private WaitForSeconds _waitForCooldown;
        private bool _canAttack = true;

        protected virtual void Awake()
        {
            enemyData = GetComponent<Enemy>().Data;
            _untilAttackPossible = new WaitUntil(() => _canAttack);
            _waitForCooldown = new WaitForSeconds(enemyData.AttackCooldown);
        }

        protected virtual IEnumerator PerformAttack()
        {
            if (!_canAttack)
                yield return _untilAttackPossible;

            while (GameManager.Player != null)
            {
                _canAttack = false;
                playerHealth.React(enemyData.Damage);
                StartCoroutine(AttackDelay());
                yield return _untilAttackPossible;
            }

            attack = null;
        }

        protected IEnumerator AttackDelay()
        {
            yield return _waitForCooldown;

            _canAttack = true;
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
                attack = StartCoroutine(PerformAttack());
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
            StopAllCoroutines();
            _canAttack = true;
            attack = null;
        }
    }
}