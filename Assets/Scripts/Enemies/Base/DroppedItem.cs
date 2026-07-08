using Relentless.Inventory;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    [System.Serializable]
    public class DroppedItem
    {
        [field: SerializeField] public ItemData Data { get; private set; }
        [Range(0.001f, 1f)]

        [SerializeField] private float _probability;
        public float Probability { get => _probability; set => _probability = value; }

        public DroppedItem(ItemData Data, float Probability)
        {
            this.Data = Data;
            _probability = Probability;
        }
    }
}
