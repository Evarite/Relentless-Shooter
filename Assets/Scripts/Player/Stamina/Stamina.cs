using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Relentless.Player.StaminaSystem
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
                //float oldValue = _currentStamina;

                //_currentStamina = Mathf.Clamp(value, _minStamina, _maxStamina);

                //if (_currentStamina < oldValue)
                //{
                //    if (_recovery != null)
                //        StopCoroutine(_recovery);
                //    _recovery = StartCoroutine(Recovery());
                //}

                _currentStamina = Mathf.Clamp(value, _minStamina, _maxStamina);
                _recoveryTimer = 0f;
            }
        }

        [Header("Recovery")]
        [SerializeField] private float _staminaRecovery = 3f;
        [Tooltip("Amount of time in seconds stamina must not be consumed for it to start recovering.")]
        [SerializeField] private float _idleTime = 3f;

        private Coroutine _recovery;
        private float _recoveryTimer = 0f;

        private void Awake()
        {
            _currentStamina = _maxStamina;
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

        //private IEnumerator Recovery()
        //{
        //    yield return new WaitForSeconds(_idleTime);

        //    while (CurrentStamina < _maxStamina)
        //    {
        //        CurrentStamina += _staminaRecovery * Time.deltaTime;
        //        yield return null;
        //    }

        //    _recovery = null;
        //}

        private void Update() //Recovery assigns to the field directly so that the setter doesn't get called
        {
            if(_currentStamina < _maxStamina)
                if (_recoveryTimer < _idleTime)
                    _recoveryTimer += Time.deltaTime;
                else
                    _currentStamina = Mathf.Min(_maxStamina,
                        _currentStamina + _staminaRecovery * Time.deltaTime);
        }
    }
}