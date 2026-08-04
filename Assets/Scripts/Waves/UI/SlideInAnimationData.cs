using UnityEngine;

namespace Relentless.Waves.UI
{
    public class SlideInAnimationData : ScriptableObject
    {
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _slideDistance = 200f;

        public float Duration { get => _duration; set => _duration = value; }
        public float SlideDistance { get => _slideDistance; set => _slideDistance = value; }
    }
}