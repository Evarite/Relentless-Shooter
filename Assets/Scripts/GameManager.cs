using UnityEngine;

namespace Relentless
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static InputSystemActions InputActions { get; private set; }

        public static GameObject Player { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            InputActions = new InputSystemActions();
            InputActions.Global.Enable();
            ActivatePlayer();
        }

        private void OnEnable()
        {
            //Subscribe to the switching aciton maps events (in another branch)
        }

        private void OnDisable()
        {
            //Unsibscribe
        }

        private void OnDestroy()
        {
            InputActions.Dispose();
        }

        public static void RegisterPlayer(GameObject player) => Player = player;
        public static void UnregisterPlayer() => Player = null;

        private void ActivatePlayer()
        {
            InputActions.Player.Enable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Disable();
        }

        private void ActivateInventory()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Enable();
            InputActions.Pause.Disable();
        }

        private void ActivatePause()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Enable();
        }
    }
}