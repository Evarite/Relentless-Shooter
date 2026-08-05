using System;
using System.Collections;
using UnityEngine;

namespace Relentless.Waves.UI
{
    [RequireComponent(typeof(BuffUIItem))]
    public abstract class BaseAnimation : MonoBehaviour
    {
        protected AnimationData _data;
        protected BuffUIItem _item;

        public event Action OnFinished;

        protected void Awake()
        {
            _item = GetComponent<BuffUIItem>();
            _data = GetComponent<InAnimationController>().Data;
        }

        protected void OnEnable() => StartCoroutine(Animation());

        protected void OnDisable() => StopAllCoroutines();

        protected abstract IEnumerator Animation();

        protected void InvokeFinished() => OnFinished?.Invoke();

#if UNITY_EDITOR
        protected abstract void OnValidate();
#endif
    }
}
