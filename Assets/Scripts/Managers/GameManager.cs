using UnityEngine;

namespace Relentless.Managers
{
    [AddComponentMenu("Relentless/Managers/Game Manager")]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public InputSystemActions InputActions { get; private set; }
        public GameObject Player { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            InputActions = new InputSystemActions();
            ActivatePlayer();
        }

        private void OnDestroy()
        {
            InputActions.Dispose();
        }

        public void RegisterPlayer(GameObject player) => Player = player;
        public void UnregisterPlayer() => Player = null;

        public void ActivatePlayer()
        {
            InputActions.Player.Enable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Disable();

            TimeManager.UnfreezeTime();
        }

        public void ActivateInventory()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Enable();
            InputActions.Pause.Disable();

            TimeManager.FreezeTime();
        }

        public void ActivatePause()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Enable();

            TimeManager.FreezeTime();
        }
    }
}