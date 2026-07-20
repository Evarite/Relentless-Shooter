using System;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves
{
    [AddComponentMenu("Relentless/Waves/Timer/Wave Timer")]
    public class WaveTimer : MonoBehaviour
    {
        [SerializeField] private WaveData _data;
        private float _time;

        public event Action OnTimeRanOut;
        public event Action<int> OnSecondChanged; //For UI to update only when second time changes

        private void Awake()
        {
            _time = _data.WaveCycleTime;
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            //So that event isn't fired at the first frame
            _time -= Time.deltaTime;
            int prevTime = (int)_time;

            yield return null;

            while (_time > 0f)
            {
                _time -= Time.deltaTime;

                if (_time <= prevTime)
                    OnSecondChanged?.Invoke(prevTime - 1);

                prevTime = (int)_time;

                yield return null;
            }

            OnTimeRanOut?.Invoke();
        }
    }
}