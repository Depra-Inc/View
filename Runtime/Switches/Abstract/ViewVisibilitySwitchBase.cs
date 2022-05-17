using System;
using Depra.View.Runtime.Switches.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Abstract
{
    public abstract class ViewVisibilitySwitchBase : IViewVisibilitySwitch, IViewVisibilitySwitchWithCallback,
        ISafeViewVisibilitySwitch
    {
        public abstract bool Visible { get; }
        
        public abstract void ShowInstantly();

        public abstract void HideInstantly();

        public abstract void Show(Action onComplete);

        public abstract void Hide(Action onComplete);

        public abstract void TryShow(Action onComplete);

        public abstract void TryHide(Action onComplete);

        public virtual void Validate(GameObject engineRoot)
        {
        }
    }
}