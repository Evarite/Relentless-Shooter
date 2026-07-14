using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Pooling
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _size = 50;
        private Queue<PooledEntity> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _size; i++)
            {
                GameObject enemy = Instantiate(_prefab, gameObject.transform);
                enemy.SetActive(false);
                _pool.Enqueue(enemy.GetComponent<PooledEntity>());
            }
        }

        public PooledEntity Get()
        {
            if (_pool.Count != 0)
            {
                PooledEntity enemy = _pool.Dequeue();
                enemy.gameObject.SetActive(true);
                return enemy;
            }

            return default;
        }

        public void Return(PooledEntity enemy)
        {
            enemy.gameObject.SetActive(false);
            _pool.Enqueue(enemy);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_prefab.GetComponent<PooledEntity>() == null)
                Debug.LogError($"[{name}]: PooledEntity component is not attached to the prefab instance!");
        }
#endif
    }
}