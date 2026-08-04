using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class BuffUIAnimationController : MonoBehaviour
    {
        [Header("Time")]
        [Tooltip("The delay for the second item to appear after the first one etc")]
        [SerializeField] private float _itemAnimationGap = 0.5f;
        [Tooltip("The amount on time the items stay on screen before starting to disappear after the" +
            "last item appeared")]
        [SerializeField] private float _stayTime = 1.5f;

        [SerializeField] private List<BuffUIItem> _items;

        private void StartInAnimation()
        {
            StartCoroutine(AnimationInController());
        }

        private void StartOutAnimation()
        {
            StartCoroutine(AnimationOutController());
        }

        private IEnumerator AnimationInController()
        {
            yield return null;
        }

        private IEnumerator AnimationOutController()
        {
            yield return null;
        }
    }
}