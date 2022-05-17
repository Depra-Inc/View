using System;
using Depra.Extensions.UnityTypes;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Animator
{
    [Serializable]
    [AddTypeMenu("Delay")]
    public class DelayedActionRouter : ExtendedMonoBehavior, IActionLifetimeRouter
    {
        [Min(0f)] [SerializeField] private float _delay = Constants.DefaultAnimationDuration;
        
        public void Init(Action onStarted, Action onCompleted)
        {
            onStarted?.Invoke();
            InvokeAtTime(_delay, onCompleted);
        }

        private void OnCompleted(Action onComplete)
        {
            StopAllCoroutines();
            onComplete?.Invoke();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}