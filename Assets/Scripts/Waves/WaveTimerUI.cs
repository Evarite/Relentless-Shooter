using TMPro;
using UnityEngine;

namespace Relentless.Waves
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(WaveTimer))]
    [AddComponentMenu("Relentless/Waves/Timer/Wave Timer UI")]
    public class WaveTimerUI : MonoBehaviour
    {
        [SerializeField] private WaveData _waveData;
        private TextMeshProUGUI _text;
        private WaveTimer _timer;

        private int _secPerMin = 60;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _timer = GetComponent<WaveTimer>();
            ResetTimer();
        }

        private void OnEnable()
        {
            _timer.OnSecondChanged += UpdateText;
        }

        private void OnDisable()
        {
            _timer.OnSecondChanged -= UpdateText;
        }

        private void UpdateText(int time)
        {

            int minutes = time / _secPerMin;
            int seconds = time % _secPerMin;

            SetText(minutes, seconds);
        }

        private void ResetTimer()
        {
            int time = (int)_waveData.WaveCycleTime;

            int minutes = time / _secPerMin;
            int seconds = time % _secPerMin;

            SetText(minutes, seconds);
        }

        private void SetText(int minutes, int seconds) => _text.text = $"{minutes}:{seconds}";
    }
}