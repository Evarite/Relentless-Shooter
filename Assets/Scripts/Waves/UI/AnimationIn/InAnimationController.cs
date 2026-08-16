using System;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(AnimationSlideIn))]
    [RequireComponent(typeof(AnimationFadeIn))]
    public class InAnimationController : MonoBehaviour, IAnimationController
    {
        private AnimationSlideIn _slideIn;
        private AnimationFadeIn _fadeIn;

        private int _activeAnimations = 0;

        private WaitUntil _waitUntilFinished;

        public event Action OnFinished;

        private void Awake()
        {
            _slideIn = GetComponent<AnimationSlideIn>();
            _fadeIn = GetComponent<AnimationFadeIn>();

            _waitUntilFinished = new WaitUntil(() => _activeAnimations == 0);
        }

        private void OnEnable()
        {
            _slideIn.OnFinished += AnimationFinished;
            _fadeIn.OnFinished += AnimationFinished;
        }

        private void OnDisable()
        {
            _slideIn.OnFinished -= AnimationFinished;
            _fadeIn.OnFinished -= AnimationFinished;

            StopAllCoroutines();
        }

        public void StartAnimation()
        {
            _slideIn.enabled = true;
            _activeAnimations++;

            _fadeIn.enabled = true;
            _activeAnimations++;

            StartCoroutine(WaitUntilFinished());
        }

        private void AnimationFinished() => _activeAnimations--;

        private IEnumerator WaitUntilFinished()
        {
            yield return _waitUntilFinished;

            OnFinished?.Invoke();
        }
    }
}