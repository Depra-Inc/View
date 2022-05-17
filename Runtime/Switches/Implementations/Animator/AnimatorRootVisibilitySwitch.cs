using System;
using Depra.Tools.Serialization.Interfaces.Runtime;
using Depra.View.Runtime.Switches.Abstract;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Animator
{
    using Animator = UnityEngine.Animator;
    using GameObject = UnityEngine.GameObject;
    
    [Serializable]
    [AddTypeMenu("Animator")]
    public class AnimatorRootVisibilitySwitch : AnimatedViewVisibilitySwitch<AnimatorRootView>
    {
        [Required] [SerializeField] private InterfaceReference<IActionLifetimeRouter> _actionRouter;

        [AnimatorParam("Animator"), SerializeField]
        private int _showTriggerHash;

        [AnimatorParam("Animator"), SerializeField]
        private int _hideTriggerHash;

        private Animator Animator => RootProvider.Animator;

        protected override void ShowOverride(Action onComplete)
        {
            RootProvider.SetRootActive(true);

            _actionRouter.Value.Init(
                () => { Animator.Play(_showTriggerHash); },
                onComplete);
        }

        protected override void HideOverride(Action onComplete)
        {
            _actionRouter.Value.Init(
                () => { Animator.Play(_hideTriggerHash); },
                onComplete);
        }

        public override void Validate(GameObject engineRoot)
        {
            ValidateAnimator(engineRoot);
            ValidateActionRouter(engineRoot);
        }

        private void ValidateAnimator(GameObject engineRoot)
        {
            if (Animator != null)
            {
                return;
            }
            
            var newAnimator = engineRoot.GetComponentInChildren<Animator>(true);
            if (newAnimator == null)
            {
                throw new NullReferenceException("Animator not found!");
            }

            RootProvider.Init(newAnimator);
        }

        private void ValidateActionRouter(GameObject engineRoot)
        {
            if (_actionRouter.Value != null)
            {
                return;
            }
            
            var newActionRouter = engineRoot.GetComponentInChildren<IActionLifetimeRouter>(true);
            if (newActionRouter == null)
            {
                throw new NullReferenceException("Action router for animator not found!");
            }

            _actionRouter.Value = newActionRouter;
        }
    }
}