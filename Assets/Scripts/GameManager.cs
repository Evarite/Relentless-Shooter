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

        public static void ActivatePlayer()
        {
            InputActions.Player.Enable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Disable();
        }

        public static void ActivateInventory()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Enable();
            InputActions.Pause.Disable();
        }

        public static void ActivatePause()
        {
            InputActions.Player.Disable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Enable();
        }
    }
}