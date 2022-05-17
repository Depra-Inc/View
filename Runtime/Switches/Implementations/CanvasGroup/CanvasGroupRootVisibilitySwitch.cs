using System;
using Depra.Extensions;
using Depra.View.Runtime.Switches.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.CanvasGroup
{
    using CanvasGroup = UnityEngine.CanvasGroup;
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    [AddTypeMenu("Canvas Group")]
    public class CanvasGroupRootVisibilitySwitch : UIViewVisibilitySwitch<CanvasGroupRootView>
    {
        [SerializeReference] [SubclassSelector]
        private CanvasGroupAnimation _animation = new DefaultCanvasGroupAnimation();

        public override bool Visible => RootProvider.RootActive && RootProvider.Alpha.Approximately(_animation.MaxValue);

        protected override void ShowOverride(Action onComplete)
        {
            RootProvider.Alpha = _animation.MinValue;
            RootProvider.SetRootActive(true);

            _animation.Play(RootProvider.CanvasGroup, _animation.MaxValue, onComplete);
        }

        protected override void HideOverride(Action onComplete)
        {
            _animation.Play(RootProvider.CanvasGroup, _animation.MinValue, onComplete);
        }

        protected override void OnEnabled(Action onComplete = null)
        {
            RootProvider.Alpha = _animation.MaxValue;
            onComplete?.Invoke();
        }

        protected override void OnDisabled(Action onComplete = null)
        {
            RootProvider.Alpha = _animation.MinValue;
            onComplete?.Invoke();
        }

        public override void Validate(GameObject parent)
        {
            if (RootProvider.CanvasGroup == null)
            {
                RootProvider.Init(parent.GetComponentInChildren<CanvasGroup>());
            }
        }
    }
}