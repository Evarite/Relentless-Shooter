using UnityEngine;
using UnityEngine.UI;

namespace Relentless.Player.StaminaSystem
{
    [RequireComponent(typeof(Slider))]
    public class StaminaUIBar : MonoBehaviour
    {
        private Slider _slider;
        [SerializeField] private Stamina _stamina;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _slider.maxValue = _stamina.MaxStamina;
            _slider.interactable = false;
        }

        private void Update()
        {
            _slider.value = _stamina.CurrentStamina;
        }
    }
}
