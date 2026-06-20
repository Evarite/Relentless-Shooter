using System.Collections;
using UnityEngine;

namespace Relentless.Player.Stamina
{
    public class Stamina : MonoBehaviour
    {
        [Header("Max Value")]
        [SerializeField] private float _maxStamina = 50f;
        [SerializeField] private float _minStamina = 0f;

        private float _currentStamina;
        public float CurrentStamina
        {
            get => _currentStamina;
            private set
            {
                float oldValue = _currentStamina;

                _currentStamina = Mathf.Clamp(value, _minStamina, _maxStamina);

                if (_currentStamina < oldValue)
                {
                    if (_recovery != null)
                        StopCoroutine(_recovery);
                    _recovery = StartCoroutine(Recovery());
                }
            }
        }

        [Header("Recovery")]
        [SerializeField] private float _staminaRecovery = 3f;
        [Tooltip("Amount of time in seconds stamina must not be consumed for it to start recovering.")]
        [SerializeField] private float _idleTime = 3f;

        private Coroutine _recovery;

        private void Awake()
        {
            CurrentStamina = _maxStamina;
        }

        public bool Consume(float value)
        {
            if (CurrentStamina >= value)
            {
                CurrentStamina -= value;
                return true;
            }
            else
                return false;
        }

        private IEnumerator Recovery()
        {
            yield return new WaitForSeconds(_idleTime);

            while (CurrentStamina < _maxStamina)
            {
                CurrentStamina += _staminaRecovery * Time.deltaTime;
                yield return null;
            }

            _recovery = null;
        }
    }
}