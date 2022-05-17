using UnityEngine;

namespace Depra.View.Runtime.Switches.Abstract
{
    public abstract class RootViewBase
    {
        public abstract bool RootActive { get; }
        
        internal abstract GameObject BaseRoot { get; }
        
        public void SetRootActive(bool activeState)
        {
            BaseRoot.SetActive(activeState);
        }
    }
}