using Relentless.Inventory;
using UnityEngine;

namespace Relentless.Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("Relentless/Pickable/Item")]
    public class Item : MonoBehaviour, IPickable
    {
        [SerializeField] private ItemData _data;
        //If an enemy drops multiple same objects as a reward
        public int Count { private get; set; } = 1;

        private bool _isPickedUp = false;

        private void Awake() => Destroy(gameObject, _data.Lifetime);

        public void PickUp(GameObject picker)
        {
            if (_isPickedUp)
                return;

            _isPickedUp = true;

            InventoryController.Instance.AddItem(_data, Count);
            Destroy(gameObject);
        }
    }
}