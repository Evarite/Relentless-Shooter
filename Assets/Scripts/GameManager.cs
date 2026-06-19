using UnityEngine;

namespace Relentless
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static InputSystemActions InputActions { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            InputActions = new InputSystemActions();
            InputActions.Player.Enable();
            InputActions.Global.Enable();
            InputActions.Inventory.Disable();
            InputActions.Pause.Disable();
        }
    }
}