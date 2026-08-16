using Relentless.HealthSystem;
using Relentless.Waves;

namespace Relentless.Enemies.Base
{
    public class EnemyHealth : Health
    {
        protected override void OnEnable() =>
            CurrentHealth = MaxHealth * BuffsModifiers.HealthBuffModifier;
    }
}
