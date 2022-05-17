using System;
using Depra.View.Runtime.Switches.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Transform
{
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    [AddTypeMenu("Transform")]
    public class TransformRootVisibilitySwitch : AnimatedViewVisibilitySwitch<TransformRootView>
    {
        [SerializeReference, SubclassSelector] private TransformSwitchAnimation _activationAnimation = null;
        [SerializeReference, SubclassSelector] private TransformSwitchAnimation _deactivationAnimation = null;
        
        protected override void ShowOverride(Action onComplete)
        {
            RootProvider.SetRootActive(true);

            if (_activationAnimation == null)
            {
                onComplete?.Invoke();
                return;
            }

            _activationAnimation.Play(RootProvider.Transform, onComplete);
        }

        protected override void HideOverride(Action onComplete)
        {
            if (_deactivationAnimation == null)
            {
                onComplete?.Invoke();
                return;
            }

            _deactivationAnimation.Play(RootProvider.Transform, onComplete);
        }

        public override void Validate(GameObject parent)
        {
            if (RootProvider.Transform == null)
            {
                RootProvider.Init(parent.transform);
            }
        }
    }
}