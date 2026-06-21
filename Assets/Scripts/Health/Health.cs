using System;
using UnityEngine;

namespace Relentless.HealthSystem
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] private float _maxHealth;
        public float MaxHealth { get => _maxHealth; }
        public float CurrentHealth { get; set; }

        private IDeathHandler _deathHandler;

        public event Action OnDamageTaken; 

        private void Awake()
        {
            CurrentHealth = _maxHealth;
            _deathHandler = GetComponent(typeof(IDeathHandler)) as IDeathHandler;
        }

        public void React(float damage)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - damage);

            OnDamageTaken?.Invoke();

            if (CurrentHealth <= 0f)
                _deathHandler.Die();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (GetComponent(typeof(IDeathHandler)) as IDeathHandler == null)
                Debug.LogError($"[{name}]: IDeathHandler is not attached!");
        }
#endif
    }
}