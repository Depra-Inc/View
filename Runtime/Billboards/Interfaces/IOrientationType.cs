using UnityEngine;

namespace Depra.View.Runtime.Billboards.Interfaces
{
    public interface IOrientationType
    {
        void Orient();

        void OrientSafely();
        
        void Reset(GameObject user);
    }
}