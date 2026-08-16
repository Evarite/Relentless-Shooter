using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class AnimationFadeIn : BaseAnimation
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

                canvasGroup.alpha = Mathf.Min(1f, t);

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
