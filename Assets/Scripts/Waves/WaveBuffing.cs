using UnityEngine;

namespace Relentless.Waves
{
    [RequireComponent(typeof(WaveTimer))]
    public class WaveBuffing : MonoBehaviour
    {
        private WaveTimer _timer;

        private void Awake() => _timer = GetComponent<WaveTimer>();

        private void OnEnable() => _timer.OnTimeRanOut += Buff;

        private void OnDisable() => _timer.OnTimeRanOut -= Buff;

        private void Buff()
        {
            Debug.Log("The event worked");
        }
    }
}
