using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [System.Serializable]
    public class UIAnimationControllerData
    {
        [Header("Buff Controller")]
        [SerializeField] private WaveBuffingController _buffController;

        [Header("Time")]
        [Tooltip("The delay for the second item to appear after the first one etc")]
        [SerializeField] private float _itemAnimationGap = 0.5f;
        [Tooltip("The amount on time the items stay on screen before starting to disappear after the" +
            "last item appeared")]
        [SerializeField] private float _stayTime = 1.5f;

        [Header("Positioning")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _xOffset = 100f;

        [Header("Items")]
        [SerializeField] private List<BuffUIItem> _items;

        public WaveBuffingController BuffController { get => _buffController; set => _buffController = value; }
        public float ItemAnimationGap { get => _itemAnimationGap; set => _itemAnimationGap = value; }
        public float StayTime { get => _stayTime; set => _stayTime = value; }
        public Vector3 StartPosition { get => _startPosition; set => _startPosition = value; }
        public float XOffset { get => _xOffset; set => _xOffset = value; }
        public List<BuffUIItem> Items { get => _items; set => _items = value; }
    }
}
