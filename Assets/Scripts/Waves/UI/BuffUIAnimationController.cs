using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Relentless.Waves.UI
{
    public class BuffUIAnimationController : MonoBehaviour
    {
        [SerializeField] UIAnimationControllerData _data;

        private List<InAnimationController> _inControllers = new();
        private List<OutAnimationController> _outControllers = new();

        private WaitForSeconds _animationGap;

        private int _activeAnimations = 0;

        public int ActiveAnimations { get => _activeAnimations; set => _activeAnimations = value; }

        private void Awake()
        {
            foreach (var item in _data.Items)
            {
                _inControllers.Add(item.GetComponent<InAnimationController>());
                _outControllers.Add(item.GetComponent<OutAnimationController>());
            }

            _animationGap = new WaitForSeconds(_data.ItemAnimationGap);
        }

        private void OnEnable()
        {
            _data.BuffController.OnBuffed += StartInAnimation;

            foreach (var controller in _inControllers)
            {
                controller.OnFinished += AnimationFinished;
            }
        }

        private void OnDisable()
        {
            _data.BuffController.OnBuffed -= StartInAnimation;

            foreach (var controller in _inControllers)
            {
                controller.OnFinished -= AnimationFinished;
            }
        }

        private void AnimationFinished() => _activeAnimations--;

        private void StartInAnimation(Dictionary<string, float> buffValues) =>
            StartCoroutine(AnimationInController(buffValues));

        private IEnumerator AnimationInController(Dictionary<string, float> buffValues)
        {
            for (int i = 0; i < _inControllers.Count; i++)
            {
                _data.Items[i].Name.text = buffValues.Keys.ToList()[i];
                _data.Items[i].Value.text =
                    $"+{buffValues.Values.ToList()[i] * 100f}%"; //*100 to convert to percentage

                _data.Items[i].RectTransform.localPosition = _data.StartPosition +
                    new Vector3(_data.XOffset * i, 0f, 0f);

                _inControllers[i].StartAnimation();
                _activeAnimations++;

                yield return _animationGap;
            }

            yield return new WaitUntil(() => _activeAnimations == 0);

            yield return new WaitForSeconds(_data.StayTime);

            StartCoroutine(AnimationOutController());
        }

        private IEnumerator AnimationOutController()
        {
            for (int i = 0; i < _outControllers.Count; i++)
            {
                _outControllers[i].StartAnimation();
                yield return _animationGap;
            }
        }
    }
}