using System;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Interfaces
{
    public interface ISafeViewVisibilitySwitch
    {
        void TryShow(Action onComplete);
        
        void TryHide(Action onComplete);
        
        void Validate(GameObject engineRoot);
    }
}