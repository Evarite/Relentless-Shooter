using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public class BuffUIItem : MonoBehaviour
    {
        private RectTransform _transform;
        private CanvasGroup _canvas;

        public RectTransform Transform { get => _transform; }
        public CanvasGroup Canvas { get => _canvas; }

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _canvas = GetComponent<CanvasGroup>();
        }
    }
}