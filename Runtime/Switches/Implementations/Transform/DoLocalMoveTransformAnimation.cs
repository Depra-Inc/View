using System;
using Depra.Extensions.Structs;
using DG.Tweening;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Transform
{
    using Transform = UnityEngine.Transform;

    [Serializable]
    [AddTypeMenu("DOLocalMove")]
    public class DoLocalMoveTransformAnimation : TransformSwitchAnimation
    {
        [SerializeField] private Vector3 _delta = new(0f, 0.5f, 0f);
        [SerializeField] private bool _useLocal = true;
        [SerializeField] private ExtendedTweenParameters _tweenParameters = new(Constants.DefaultAnimationDuration);

        private Tweener _animationTween;

        public override void Play(Transform target, Action onComplete = null)
        {
            var startPosition = _useLocal ? target.localPosition : InitialValue;
            var targetPosition = startPosition + _delta;

            _animationTween.Kill();
            _animationTween = target.DOLocalMove(targetPosition, _tweenParameters.Duration)
                .SetUpdate(_tweenParameters.Update)
                .SetEase(_tweenParameters.Ease)
                .OnComplete(() => onComplete?.Invoke());
        }

        public override void Dispose()
        {
            _animationTween.Kill();
        }
    }
}