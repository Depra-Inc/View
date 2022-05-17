using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Interfaces
{
    [PublicAPI]
    public interface ISafeViewVisibilitySwitch
    {
        void TryShow(Action onComplete);
        
        void TryHide(Action onComplete);
        
        void Validate(GameObject engineRoot);
    }
}