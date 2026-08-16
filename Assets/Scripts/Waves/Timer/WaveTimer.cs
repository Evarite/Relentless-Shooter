using System;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves
{
    [AddComponentMenu("Relentless/Waves/Timer/Wave Timer")]
    public class WaveTimer : MonoBehaviour
    {
        [SerializeField] private WaveData _data;

        private static WaitForSeconds _firstSecondDelay = new WaitForSeconds(1f);

        public event Action OnTimeRanOut;
        public event Action<int> OnSecondChanged; //For UI to update only when second time changes

        private void Awake()
        {
            StartCoroutine(Timer());
        }

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Timer()
        {
            while (true)
            {
                float time = _data.WaveCycleTime;
                int displayedTime = (int)time;

                OnSecondChanged?.Invoke(displayedTime);

                //Waiting for a second, so that the first second isn't skipped immediately
                yield return _firstSecondDelay;

                while (time > 0f)
                {
                    time -= Time.deltaTime;

                    if (time <= 0f)
                        break;

                    if (time <= displayedTime)
                        OnSecondChanged?.Invoke(displayedTime - 1);

                    displayedTime = (int)time;

                    yield return null;
                }

                OnTimeRanOut?.Invoke();
            }
        }
    }
}