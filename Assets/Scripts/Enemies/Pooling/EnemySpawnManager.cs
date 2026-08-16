using Relentless.Managers;
using Relentless.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Enemies.Pooling
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] private SpawnManagerData _data;

        private WaitForSeconds _waitForSpawnInterval;
        private WaitForSeconds _waitForDespawnInterval;

        //TODO
        //Add probabilities of spawning each type of enemy

        private List<PooledEntity> _enemies = new();

        private void Awake()
        {
            _waitForSpawnInterval = new WaitForSeconds(_data.SpawnInterval);
            _waitForDespawnInterval = new WaitForSeconds(_data.DespawnInterval);

            foreach (var pool in _data.EnemyPools)
                pool.Initialize(LayerMask.NameToLayer("Enemies"));
        }

        private void OnEnable()
        {
            StartCoroutine(Spawn());
            StartCoroutine(Despawn());
        }

        private void OnDisable() => StopAllCoroutines();

        //For now, it works with single pool, later I'll add multiple
        //TODO
        //Remove magic numbers
        private IEnumerator Spawn()
        {
            while (true)
            {
                if (GameManager.Instance.Player == null)
                    yield return new WaitUntil(() => GameManager.Instance.Player != null);

                Vector2 playerPos = GameManager.Instance.Player.transform.position;

                if (_enemies.Count > _data.MaxEnemiesCount)
                    yield return new WaitUntil(() => _enemies.Count < _data.MaxEnemiesCount);

                var pool = _data.EnemyPools.GetRandomItem();
                if (pool != null)
                {
                    PooledEntity enemy = pool.Get();
                    if (enemy != null)
                    {
                        float x = Random.Range(-1f, 1f);
                        float y = Random.Range(-1f, 1f);
                        Vector2 direction = new Vector2(x, y);
                        if (direction == Vector2.zero)
                            direction = Vector2.up;

                        enemy.transform.position = playerPos + direction.normalized * _data.SpawnDistance;

                        _enemies.Add(enemy);
                    }
                }

                yield return _waitForSpawnInterval;
            }
        }

        private IEnumerator Despawn()
        {
            while (true)
            {
                Vector3 playerPos = GameManager.Instance.Player != null
                    ? GameManager.Instance.Player.transform.position
                    : Vector3.zero;

                for (int i = _enemies.Count - 1; i >= 0; i--)
                {
                    if ((playerPos - _enemies[i].transform.position).sqrMagnitude >
                        _data.MaxDistance * _data.MaxDistance)
                    {
                        _enemies[i].Return();
                        _enemies.RemoveAt(i);
                    }
                }

                yield return _waitForDespawnInterval;
            }
        }
    }
}