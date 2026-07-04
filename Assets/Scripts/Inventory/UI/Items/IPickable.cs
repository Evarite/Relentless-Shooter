using UnityEngine;

namespace Assets.Scripts.Inventory.UI.Items
{
    public interface IPickable
    {
        void PickUp(GameObject picker);
    }
}