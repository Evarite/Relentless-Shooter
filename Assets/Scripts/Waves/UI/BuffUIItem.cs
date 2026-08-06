using TMPro;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasGroup))]
    public class BuffUIItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _value;

        private RectTransform _rectTransform;
        private CanvasGroup _canvas;

        public RectTransform RectTransform { get => _rectTransform; }
        public CanvasGroup Canvas { get => _canvas; }
        public TextMeshProUGUI Name { get => _name; set => _name = value; }
        public TextMeshProUGUI Value { get => _value; set => _value = value; }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponent<CanvasGroup>();
        }
    }
}