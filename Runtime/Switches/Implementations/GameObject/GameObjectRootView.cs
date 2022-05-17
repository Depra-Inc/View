using System;
using Depra.View.Runtime.Switches.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.GameObject
{
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    public class GameObjectRootView : RootViewBase
    {
        [SerializeField] private GameObject _gameObject;

        public override bool RootActive => _gameObject.activeSelf;

        internal override GameObject BaseRoot => _gameObject;
    }
}