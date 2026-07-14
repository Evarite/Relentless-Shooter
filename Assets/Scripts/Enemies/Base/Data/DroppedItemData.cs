using Relentless.Items;
using UnityEngine;

namespace Relentless.Enemies.Base.Data
{
    [System.Serializable]
    public class DroppedItemData
    {
        [Header("Item Drop")]
        [SerializeField] private ItemData _item;
        [Min(1)]
        [SerializeField] private int _minDropCount = 1;
        [SerializeField] private int _maxDropCount = 2;

        public ItemData Item { get => _item; set => _item = value; }
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
