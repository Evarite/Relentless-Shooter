using UnityEngine;
using Relentless.HealthSystem;
using UnityEngine.UI;

namespace Relentless.Player.HealthSystem
{
    [RequireComponent(typeof(Slider))]
    [AddComponentMenu("Relentless/Player/UI/Health UI Bar")]

    public class HealthUIBar : MonoBehaviour
    {
        [SerializeField] private Health _playerHealth;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            
            _slider.interactable = false;
            _slider.maxValue = _playerHealth.MaxHealth;
        }

        private void Update()
        {
            _slider.value = _playerHealth.CurrentHealth;
        }
    }
}
