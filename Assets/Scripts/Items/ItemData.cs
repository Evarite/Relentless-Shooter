using UnityEngine;

namespace Relentless.Items
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Relentless/Inventory/Item")]
    public class ItemData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public bool IsStackable { get; private set; } = true;
        [field: SerializeField] public int MaxStackSize { get; private set; } = 99;
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
