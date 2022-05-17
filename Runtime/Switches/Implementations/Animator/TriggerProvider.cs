using System;

namespace Depra.View.Runtime.Switches.Implementations.Animator
{
    public interface IActionLifetimeRouter
    {
        void Init(Action onStarted, Action onCompleted);
    }
}