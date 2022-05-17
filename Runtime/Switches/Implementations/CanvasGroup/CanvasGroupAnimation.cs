using System;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.CanvasGroup
{
    using CanvasGroup = UnityEngine.CanvasGroup;
    
    [Serializable]
    public abstract class CanvasGroupAnimation : IDisposable
    {
        [MinMaxSlider(0f, 1f)] [SerializeField]
        private Vector2 _minMaxValues = new(0f, 1f);
        
        internal float MinValue => _minMaxValues.x;
        internal float MaxValue => _minMaxValues.y;
        
        public abstract void Play(CanvasGroup target, float targetAlpha, Action onComplete = null);

        public abstract void Dispose();
    }
}