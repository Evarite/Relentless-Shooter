using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class Animation : MonoBehaviour
    {
        private AnimationData _data;
        private BuffUIItem _item;

        private void Awake()
        {
            _item = GetComponent<BuffUIItem>();
            _data = GetComponent<InAnimationController>().Data;
        }

        private void OnEnable() => StartCoroutine(Animation());

        private void OnDisable() => StopAllCoroutines();

        private abstract IEnumerator Animation();

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (GetComponent<InAnimationController>() == null)
                Debug.LogError($"[{name}]: InAnimationController is not attached!");
        }
#endif
    }
}
