using Relentless.HealthSystem;
using UnityEngine;

namespace Relentless.Player.HealthSystem
{
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
