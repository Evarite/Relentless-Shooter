using Assets.Scripts.Inventory.UI.Items;
using UnityEngine;

namespace Relentless.Behaviours
{
    [RequireComponent(typeof(CircleCollider2D))]
    [AddComponentMenu("Relentless/Behaviours/Pick Up Handler")]
    public class PickUpHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _picker; 
        protected virtual bool AdditionalCondition(Collider2D collision, IPickable pickable) => true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IPickable pickable) &&
                AdditionalCondition(collision, pickable))
                pickable.PickUp(_picker);
        }
    }
}
