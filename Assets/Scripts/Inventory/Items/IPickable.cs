using UnityEngine;

namespace Relentless.Inventory.Items
{
    public interface IPickable
    {
        void PickUp(GameObject picker);
    }
}