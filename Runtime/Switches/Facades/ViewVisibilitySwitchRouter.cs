using System;
using Depra.View.Runtime.Switches.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Facades
{
    [Serializable]
    [AddTypeMenu("Root Behavior Router")]
    public class ViewVisibilitySwitchRouter : IViewVisibilitySwitch
    {
        [SerializeField] private ViewVisibilitySwitchHook _viewVisibilitySwitchHook;

        public void Show(Action onComplete) => _viewVisibilitySwitchHook.Show(onComplete);

        public void ShowInstantly() => _viewVisibilitySwitchHook.ShowInstantly();

        public void Hide(Action onComplete) => _viewVisibilitySwitchHook.Hide(onComplete);

        public void HideInstantly() => _viewVisibilitySwitchHook.HideInstantly();

        public void Validate(GameObject engineRoot) => _viewVisibilitySwitchHook.Validate(engineRoot);
    }
}