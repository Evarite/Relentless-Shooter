using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(BuffUIItem))]
    public class BuffItemSlideIn : MonoBehaviour
    {
        [SerializeField] private SlideInAnimationData _data;
        private BuffUIItem _item;

        private void Awake() => _item = GetComponent<BuffUIItem>();

        private void OnEnable() => StartCoroutine(Animation());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Animation()
        {
            RectTransform itemTransform = _item.Transform;

            itemTransform.position += new Vector3(0, _data.SlideDistance);

            yield return null;
        }
    }
}