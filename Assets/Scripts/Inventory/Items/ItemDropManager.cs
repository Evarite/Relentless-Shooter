using System;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Inventory.Items
{
    public class ItemDropManager : MonoBehaviour
    {
        public static ItemDropManager Instance;

        private List<DropData> _activeDrops = new();

        [SerializeField] private DropSettings _dropSettings;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void SpawnDroppedItem(GameObject prefab)
        {
            Vector2 direction = UnityEngine.Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)GameManager.Player.transform.position + direction *
                _dropSettings.SpawnDistance; //Player can't be null now
            Quaternion spawnRotation = Quaternion.Euler(0, 0,
                UnityEngine.Random.Range(_dropSettings.MinSpawnAngle, _dropSettings.MaxSpawnAngle)
                );

            GameObject spawnedItem = Instantiate(prefab, spawnPosition, spawnRotation);

            RegisterDrop(spawnedItem.transform,
                UnityEngine.Random.Range(_dropSettings.MinDistance, _dropSettings.MaxDistance) *
                _dropSettings.Friction * direction,
                UnityEngine.Random.Range(_dropSettings.MinRotSpeed, _dropSettings.MaxRotSpeed),
                null);
        }

        private void RegisterDrop(Transform transform, Vector2 velocity, float angularVelocity,
                Action onDropComplete)
        {
            _activeDrops.Add(new DropData(transform, velocity, angularVelocity, onDropComplete));
        }

        private void Update()
        {
            for(int i = _activeDrops.Count - 1; i >= 0; i--)
            {
                var drop = _activeDrops[i];

                drop.Transform.position += (Vector3)drop.Velocity * Time.deltaTime;
                drop.Velocity *= (1f - _dropSettings.Friction * Time.deltaTime);

                drop.Transform.Rotate(0, 0, drop.AngularVelocity * Time.deltaTime);
                drop.AngularVelocity *= (1f - _dropSettings.Friction * Time.deltaTime);

                if(drop.Velocity.magnitude < _dropSettings.StopThreshold)
                {
                    drop.AngularVelocity = 0f;
                    _activeDrops.RemoveAt(i);
                    drop.OnDropComplete?.Invoke();
                }
            }
        }

        private class DropData
        {
            public Transform Transform { get; set; }
            public Vector2 Velocity { get; set; }
            public float AngularVelocity { get; set; }
            public Action OnDropComplete { get; set; }

            public DropData(Transform transform, Vector2 velocity, float angularVelocity,
                Action onDropComplete)
            {
                Transform = transform;
                Velocity = velocity;
                AngularVelocity = angularVelocity;
                OnDropComplete = onDropComplete;
            }
        }
    }
}