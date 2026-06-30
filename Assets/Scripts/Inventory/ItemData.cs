using UnityEngine;

namespace Relentless.Inventory
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Relentless/Inventory/Item")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; }
        [field: SerializeField] public Sprite Icon { get; }
        [field: SerializeField] public bool IsStackable { get; } = true;
        [field: SerializeField] public int MaxStackSize { get; } = 200;
    }
}
