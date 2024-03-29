﻿using System;
using Depra.Extensions.Structs;
using DG.Tweening;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Transform
{
    using Transform = UnityEngine.Transform;
    
    [Serializable]
    [AddTypeMenu("DO Scale")]
    public class DoScaleTransformAnimation : TransformSwitchAnimation
    {
        [SerializeField] private Vector3 _delta = Vector3.one;
        [SerializeField] private bool _useLocal = true;
        [SerializeField] private ExtendedTweenParameters _tweenParameters = new();

        private Tweener _animationTween;
        
        public override void Play(Transform target, Action onComplete = null)
        {
            target.localScale = InitialValue;

            var initialScale = _useLocal ? target.localScale : InitialValue;
            var targetScale = initialScale + _delta;

            _animationTween.Kill();
            _animationTween = target.DOScale(targetScale, _tweenParameters.Duration)
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