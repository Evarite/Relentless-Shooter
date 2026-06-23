using UnityEngine;

namespace Relentless.Player
{
    public class PlayerManager : MonoBehaviour
    {
        //Idk, maybe it's better to do with awake and destroy but that fully depends on me

        private void OnEnable()
        {
            GameManager.RegisterPlayer(gameObject);
        }

        private void OnDisable()
        {
            GameManager.UnregisterPlayer();
        }
    }
}
