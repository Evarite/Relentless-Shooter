using UnityEngine;

namespace Relentless.HealthSystem
{
    [RequireComponent(typeof(Health))]
    [AddComponentMenu("Relentless/Health/Heal")]
    public class Heal : MonoBehaviour
    {
        [SerializeField] private float _healValue;

        [Tooltip("Amount of time the player must not take any damage to start healing")]
        [SerializeField] private float _idleTime;

        private Health _health;

        private float _idleTimer = 0f;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.OnDamageTaken += OnDamage;
        }

        private void OnDisable()
        {
            _health.OnDamageTaken -= OnDamage;
        }

        private void OnDamage()
        {
            _idleTimer = 0f;
        }

        private void Update()
        {
            if(_health.CurrentHealth < _health.MaxHealth)
            {
                if(_idleTimer >= _idleTime)
                {
                    _health.CurrentHealth = Mathf.Min(_health.MaxHealth,
                        _health.CurrentHealth + _healValue * Time.deltaTime);
                }
                else 
                {
                    _idleTimer += Time.deltaTime;
                }
            }
        }
    }
}
