using UnityEngine;

namespace Relentless.Inventory.UI
{
    public class InventoryUITopLayer : MonoBehaviour
    {
        public static InventoryUITopLayer Instance { get; private set; }

        private Transform _onTopLayer; 

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _onTopLayer = GetComponent<Transform>();
        }

        public static Transform GetTopLayer() => Instance._onTopLayer;
    }
}
