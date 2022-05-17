using JetBrains.Annotations;

namespace Depra.View.Runtime.Switches.Interfaces
{
    [PublicAPI]
    public interface IViewVisibilitySwitch
    {
        /// <summary>
        /// Instantly shows the root.
        /// </summary>
        void ShowInstantly();
        
        /// <summary>
        /// Instantly hides the root.
        /// </summary>
        void HideInstantly();
    }
}