using System;
using Depra.View.Runtime.Switches.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.CanvasGroup
{
    using CanvasGroup = UnityEngine.CanvasGroup;
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    public class CanvasGroupRootView : RootViewBase
    {
        [field: SerializeField] internal CanvasGroup CanvasGroup { get; private set; }

        public override bool RootActive => BaseRoot.activeSelf;

        internal override GameObject BaseRoot => CanvasGroup.gameObject;

        internal float Alpha
        {
            get => CanvasGroup.alpha;
            set => CanvasGroup.alpha = value;
        }

        public void Init(CanvasGroup canvasGroup)
        {
            CanvasGroup = canvasGroup;
        }
    }
}