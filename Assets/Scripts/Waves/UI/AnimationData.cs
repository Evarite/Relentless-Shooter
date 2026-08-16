using UnityEngine;

namespace Relentless.Waves.UI
{
    [CreateAssetMenu(fileName = "Animation In Data", menuName = "Relentless/Waves/Animations/In")]
    public class AnimationData : ScriptableObject
    {
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _slideDistance = 200f;

        public float Duration { get => _duration; set => _duration = value; }
        public float SlideDistance { get => _slideDistance; set => _slideDistance = value; }
    }
}