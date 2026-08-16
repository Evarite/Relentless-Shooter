using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class AnimationFadeOut : BaseAnimation
    {
        protected override IEnumerator Animation()
        {
            CanvasGroup canvasGroup = _item.Canvas;

            float elapsed = 0f;

            yield return null;

            while (elapsed <= _data.Duration)
            {
                elapsed += Time.unscaledDeltaTime;

                float t = elapsed / _data.Duration;

                canvasGroup.alpha = 1 - Mathf.Min(1f, t);

                yield return null;
            }

            InvokeFinished();

            enabled = false;
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            if (GetComponent<OutAnimationController>() == null)
                Debug.LogError($"[{name}]: OutAnimationController is not attached!");
        }
#endif
    }
}