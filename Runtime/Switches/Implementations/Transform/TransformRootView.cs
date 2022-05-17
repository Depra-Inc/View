using System;
using Depra.View.Runtime.Switches.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Transform
{
    using Transform = UnityEngine.Transform;
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    public class TransformRootView : RootViewBase
    {
        [field: SerializeField] internal Transform Transform { get; private set; }

        public override bool RootActive => Transform.gameObject.activeSelf;

        internal override GameObject BaseRoot => Transform.gameObject;

        public void Init(Transform transform)
        {
            Transform = transform;
        }
    }
}