using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(AnimationSlideIn))]
    [RequireComponent(typeof(AnimationFadeIn))]
    public class InAnimationController : MonoBehaviour
    {
        [SerializeField] private AnimationData _data;

        private AnimationSlideIn _slideIn;
        private AnimationFadeIn _fadeIn;

        public AnimationData Data { get => _data; }

        private void Awake()
        {
            _slideIn = GetComponent<AnimationSlideIn>();
            _fadeIn = GetComponent<AnimationFadeIn>();
        }

        public void StartAnimation()
        {
            _slideIn.enabled = true;
            _fadeIn.enabled = true;
        }
    }
}