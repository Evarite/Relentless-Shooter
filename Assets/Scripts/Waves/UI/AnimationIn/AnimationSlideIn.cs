using Relentless.Utilities;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class AnimationSlideIn : BaseAnimation //MonoBehaviour
    {
        protected override IEnumerator Animation()
        {
            RectTransform itemTransform = _item.RectTransform;
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

            InvokeFinished();

            enabled = false;
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            if (GetComponent<InAnimationController>() == null)
                Debug.LogError($"[{name}]: InAnimationController is not attached!");
        }
#endif
    }
}