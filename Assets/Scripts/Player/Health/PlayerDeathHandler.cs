using Relentless.HealthSystem;
using UnityEngine;

namespace Relentless.Player.HealthSystem
{
    [AddComponentMenu("Relentless/Player/Health System/Player Death Handler")]
    public class PlayerDeathHandler : MonoBehaviour, IDeathHandler
    {
        public void Die()
        {
            //TODO
            //Some particles or animation or anything like that.
            Destroy(gameObject);
        }
    }
}
