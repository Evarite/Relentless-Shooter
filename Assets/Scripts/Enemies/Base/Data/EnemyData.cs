using Relentless.Utilities.WeightedRandom;
using UnityEngine;

namespace Relentless.Enemies.Base.Data
{
    [CreateAssetMenu(menuName = "Relentless/Enemies/Enemy Data", fileName = "New Enemy")]
    public class EnemyData : ScriptableObject
    {
        [Header("Attack")]
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _attackCooldown = 1f;

        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [Tooltip("The distance between an enemy and the player at which the movement is stopped")]
        [SerializeField] private float _stopThreshold = 1f;

        [Header("Item Drop")]
        [SerializeField] private WeightedRandomList<DroppedItemData> _possibleDrops;
        [SerializeField] private int _dropIterations;

        public float Damage { get => _damage; set => _damage = value; }
        public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float StopThreshold { get => _stopThreshold; set => _stopThreshold = value; }
        public WeightedRandomList<DroppedItemData> PossibleDrops { get => _possibleDrops; }
        public int DropIterations { get => _dropIterations; set => _dropIterations = value; }

        //TODO Create a method for adding a possible drop and changing random weight
        //Create a method for removing a possible drop
    }
}