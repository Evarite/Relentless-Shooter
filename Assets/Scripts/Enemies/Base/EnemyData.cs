using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [CreateAssetMenu(menuName = "Relentless/Enemy Data", fileName = "New Enemy")]
    public class EnemyData : ScriptableObject
    {
        [Header("Sprite")]
        [SerializeField] private Sprite _sprite;

        [Header("Attack")]
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _attackCooldown = 1f;

        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [Tooltip("The distance between an enemy and the player at which the movement is stopped")]
        [SerializeField] private float _stopThreshold = 1f;

        [Header("Item Drop")]
        [SerializeField] private List<DroppedItem> _possibleDrops = new();
        [Min(1)]
        [SerializeField] private int _minDropCount = 1;
        [SerializeField] private int _maxDropCount = 2;

        public Sprite Sprite { get => _sprite; }
        public float Damage { get => _damage; set => _damage = value; }
        public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float StopThreshold { get => _stopThreshold; set => _stopThreshold = value; }
        public IReadOnlyList<DroppedItem> PossibleDrops { get => _possibleDrops; }
        public int MinDropCount { get => _minDropCount; set => _minDropCount = value; }
        public int MaxDropCount { get => _maxDropCount; set => _maxDropCount = value; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_maxDropCount < _minDropCount)
                _maxDropCount = _minDropCount;
        }
#endif
    }
}