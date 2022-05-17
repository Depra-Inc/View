using System;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Abstract
{
    [Serializable]
    public abstract class AnimatedViewVisibilitySwitch<TRoot> : ViewVisibilitySwitchBase
        where TRoot : RootViewBase, new()
    {
        [field: SerializeField] public TRoot RootProvider { get; private set; } = new();

        public override bool Visible => RootProvider.RootActive;

        public override void Show(Action onComplete) => ShowOverride(() => OnEnabled(onComplete));

        public override void Hide(Action onComplete) => HideOverride(() => HideInstantly(onComplete));

        protected abstract void ShowOverride(Action onComplete);

        protected abstract void HideOverride(Action onComplete);
        
        public void TryShow() => TryShow(null);

        public override void TryShow(Action onComplete)
        {
            if (Visible == false)
            {
                Show(onComplete);
            }
        }

        public void TryHide() => TryHide(null);

        public override void TryHide(Action onComplete)
        {
            if (Visible)
            {
                Hide(onComplete);
            }
        }

        public override void ShowInstantly()
        {
            RootProvider.SetRootActive(true);
            OnEnabled();
        }

        public override void HideInstantly() => HideInstantly(null);

        private void HideInstantly(Action onComplete)
        {
            RootProvider.SetRootActive(false);
            OnDisabled(onComplete);
        }

        protected virtual void OnEnabled(Action onComplete = null)
        {
            onComplete?.Invoke();
        }

        protected virtual void OnDisabled(Action onComplete = null)
        {
            onComplete?.Invoke();
        }
    }
}