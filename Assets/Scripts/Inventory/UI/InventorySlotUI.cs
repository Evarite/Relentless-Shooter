using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Relentless.Inventory.UI
{
    [AddComponentMenu("Relentless/Inventory/UI/Inventory Slot UI")]
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshPro _countText;

        public void SetData(InventorySlot data)
        {
            if(data.ItemData == null)
            {
                _icon.sprite = null;
                _icon.enabled = false;
                _countText.text = string.Empty;
                return;
            }

            _icon.enabled = true;
            _icon.sprite = data.ItemData.Icon;
            _countText.text = data.Count.ToString();
        }
    }
}
