using TMPro;
using UnityEngine;

namespace Relentless.Waves
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [AddComponentMenu("Relentless/Waves/Timer/Wave Timer UI")]
    public class WaveTimerUI : MonoBehaviour
    {
        [SerializeField] private WaveData _waveData;
        [SerializeField] private WaveTimer _timer;
        private TextMeshProUGUI _text;

        private int _secPerMin = 60;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable() => _timer.OnSecondChanged += UpdateText;

        private void OnDisable() => _timer.OnSecondChanged -= UpdateText;

        private void UpdateText(int time)
        {
            CalculateTime(time, out var minutes, out var seconds);

            SetText(minutes, seconds);
        }

        private void CalculateTime(int time, out int minutes, out int seconds)
        {
            minutes = time / _secPerMin;
            seconds = time % _secPerMin;
        }

        //fdsfasdfasd

        private void SetText(int minutes, int seconds) => _text.text = $"{minutes}:{seconds:D2}";
    }
}