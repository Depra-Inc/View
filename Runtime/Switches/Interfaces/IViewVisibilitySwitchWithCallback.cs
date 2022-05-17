using System;
using JetBrains.Annotations;

namespace Depra.View.Runtime.Switches.Interfaces
{
    [PublicAPI]
    public interface IViewVisibilitySwitchWithCallback
    {
        /// <summary>
        /// Causes root activation (possibly with animation).
        /// </summary>
        /// <param name="onComplete">
        /// Callback to complete the show animation.
        /// Called immediately if there is no animation.
        /// </param>
        void Show(Action onComplete);
        
        /// <summary>
        /// Causes hiding of the root (possibly with animation).
        /// </summary>
        /// <param name="onComplete">
        /// Callback to complete the hide animation.
        /// Called immediately if there is no animation.
        /// </param>
        void Hide(Action onComplete);
    }
}