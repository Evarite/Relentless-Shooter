using UnityEditor;
using UnityEngine;

namespace Relentless.Inventory.Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("Relentless/Pickable/Item")]
    public class Item : MonoBehaviour, IPickable
    {
        [SerializeField] private ItemData _data;
        //If an enemy drops multiple same objects as a reward
        public int Quantity { private get; set; } = 1;

        private bool _isPickedUp = false;

        public void PickUp(GameObject picker)
        {
            if (_isPickedUp)
                return;

            _isPickedUp = true;

            InventoryController.AddItem(_data, Quantity);
            Destroy(gameObject);
        }
    }
}