using UnityEngine;

namespace Relentless.Waves
{
    [System.Serializable]
    public static class BuffsModifiers
    {
        [SerializeField] private static float _healthBuffModifier = 1f;
        [SerializeField] private static float _damageBuffModifier = 1f;
        [SerializeField] private static float _speedBuffModifier = 1f;

        public static float HealthBuffModifier
        { get => _healthBuffModifier; set => _healthBuffModifier = value; }
        public static float DamageBuffModifier
        { get => _damageBuffModifier; set => _damageBuffModifier = value; }
        public static float SpeedBuffModifier
        { get => _speedBuffModifier; set => _speedBuffModifier = value; }
    }
}
