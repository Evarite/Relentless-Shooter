using TMPro;
using UnityEngine;

namespace Relentless.Inventory.UI
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _icon;
        [SerializeField] private TextMeshPro _quantityText;
        //[SerializeField] private TextMeshPro _nameText;

        public void SetData(InventorySlot data)
        {
            if(data.ItemData == null)
            {
                _icon.sprite = null;
                _quantityText.text = string.Empty;
                //_nameText.text = string.Empty;
                return;
            }

            _icon.sprite = data.ItemData.Icon;
            _quantityText.text = data.Quantity.ToString();
            //_nameText.text = data.ItemData.Name;
        }
    }
}
