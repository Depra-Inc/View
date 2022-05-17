using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Animator
{
    public class AnimatedActionRouter : MonoBehaviour, IActionLifetimeRouter
    {
        [SerializeField] private bool _callOnStarted = true;

        private event Action Started;
        private event Action Completed;

        public void Init(Action onStarted, Action onCompleted)
        {
            Started = onStarted;
            Completed = onCompleted;

            if (_callOnStarted)
            {
                OnStarted();
            }
        }

        [PublicAPI]
        public void OnStarted()
        {
            Started?.Invoke();
            Started = null;
        }

        [PublicAPI]
        public void OnCompleted()
        {
            Completed?.Invoke();
            Completed = null;
        }

        private void OnDestroy()
        {
            Started = null;
            Completed = null;
        }
    }
}