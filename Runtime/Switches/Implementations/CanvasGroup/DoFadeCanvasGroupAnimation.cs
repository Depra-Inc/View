using System;
using Depra.Extensions.Structs;
using DG.Tweening;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.CanvasGroup
{
    using CanvasGroup = UnityEngine.CanvasGroup;

    [Serializable]
    [AddTypeMenu("DoFade")]
    public class DoFadeCanvasGroupAnimation : CanvasGroupAnimation
    {
        [SerializeField] private ExtendedTweenParameters _tweenParameters = new(Constants.DefaultAnimationDuration);

        private Tweener _tween;

        public override void Play(CanvasGroup target, float targetAlpha, Action onComplete = null)
        {
            _tween?.Kill();

            _tween = target.DOFade(targetAlpha, _tweenParameters.Duration)
                .SetUpdate(_tweenParameters.Update)
                .SetEase(_tweenParameters.Ease)
                .OnComplete(() => onComplete?.Invoke());
        }

        public override void Dispose()
        {
            _tween?.Kill();
        }
    }
}