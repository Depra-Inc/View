using System;
using Depra.View.Runtime.Switches.Abstract;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Animator
{
    using Animator = UnityEngine.Animator;
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    public class AnimatorRootView : RootViewBase
    {
        [Required] [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _subRoot;

        public override bool RootActive => BaseRoot.activeInHierarchy;
        
        internal override GameObject BaseRoot => _subRoot ? _subRoot : _animator.gameObject;
        internal Animator Animator => _animator;

        public void Init(Animator animator)
        {
            _animator = animator;
        }
    }
}