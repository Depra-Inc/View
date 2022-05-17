using JetBrains.Annotations;

namespace Depra.View.Runtime.Switches.Interfaces
{
    public interface IViewVisibilitySwitch
    {
        /// <summary>
        /// Instantly shows the root.
        /// </summary>
        [PublicAPI]
        void ShowInstantly();
        
        /// <summary>
        /// Instantly hides the root.
        /// </summary>
        [PublicAPI]
        void HideInstantly();
    }
}