using System;

namespace Depra.View.Runtime.Switches.Implementations.CanvasGroup
{
    using CanvasGroup = UnityEngine.CanvasGroup;
    
    [Serializable]
    [AddTypeMenu("Instantly")]
    public class DefaultCanvasGroupAnimation : CanvasGroupAnimation
    {
        public override void Play(CanvasGroup target, float targetAlpha, Action onComplete = null)
        {
            target.alpha = targetAlpha;
            onComplete?.Invoke();
        }

        public override void Dispose()
        {
        }
    }
}