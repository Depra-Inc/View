using System;
using Depra.View.Runtime.Switches.Abstract;
using Depra.View.Runtime.Switches.Implementations.Transform;
using Depra.View.Runtime.Switches.Interfaces;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Facades
{
    public class ViewVisibilitySwitchHook : MonoBehaviour, IViewVisibilitySwitch, IViewVisibilitySwitchWithCallback
    {
        [SerializeReference, SubclassSelector]
        private ViewVisibilitySwitchBase _viewSwitch = new TransformRootVisibilitySwitch();

        public bool Visible => _viewSwitch.Visible;

        private void OnEnable()
        {
            _viewSwitch.Validate(gameObject);
            Show();
        }

        [Button]
        public void Show() => Show(null);

        public void Show(Action onComplete) => _viewSwitch.TryShow(onComplete);

        [Button]
        public void Hide() => Hide(null);

        public void Hide(Action onComplete) => _viewSwitch.TryHide(onComplete);

        public void ShowInstantly() => _viewSwitch.ShowInstantly();

        public void HideInstantly() => _viewSwitch.HideInstantly();

        public void ChangeType(ViewVisibilitySwitchBase newRootView)
        {
            _viewSwitch = newRootView ?? throw new NullReferenceException("Root is null!");
        }

        public void Validate(GameObject engineRoot) => _viewSwitch.Validate(engineRoot);

        [Button]
        public void Reset() => Validate(gameObject);

        private void OnValidate()
        {
            if (_viewSwitch == null)
            {
                throw new NullReferenceException($"View switch {gameObject.name} is null!");
            }
        }
    }
}