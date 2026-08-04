using Relentless.Utilities;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(BuffUIItem))]
    public class BuffItemSlideIn : MonoBehaviour
    {
        [SerializeField] private SlideInAnimationData _data;
        private BuffUIItem _item;

        private void Awake() => _item = GetComponent<BuffUIItem>();

        private void OnEnable() => StartCoroutine(Animation());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Animation()
        {
            RectTransform itemTransform = _item.Transform;
            float elapsed = 0f;

            Vector3 goalPosition = itemTransform.localPosition;
            Vector3 startPosition = itemTransform.localPosition + Vector3.up * _data.SlideDistance;

            yield return null;

            while (elapsed <= _data.Duration)
            {
                elapsed += Time.unscaledDeltaTime;

                float t = elapsed / _data.Duration;
                float easedT = Easings.EaseOutQuart(t);

                itemTransform.localPosition = Vector3.Lerp(startPosition, goalPosition, easedT);
                yield return null;
            }
        }
    }
}