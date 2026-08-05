using System;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(AnimationFadeOut))]
    public class OutAnimationController : MonoBehaviour, IAnimationController
    {
        private AnimationFadeOut _fadeOut;

        public event Action OnFinished;

        private void Awake() => _fadeOut = GetComponent<AnimationFadeOut>();

        private void OnEnable() => _fadeOut.OnFinished += InvokeFinished;

        private void OnDisable() => _fadeOut.OnFinished -= InvokeFinished;

        private void InvokeFinished() => OnFinished?.Invoke();

        public void StartAnimation() => _fadeOut.enabled = true;
    }
}