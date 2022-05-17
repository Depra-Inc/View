using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always be rotated in direction.
    /// </summary>
    [ExecuteAlways]
    public class BillboardLookToDirection : Billboard<Vector3>
    {
        [SerializeField] private bool _useLocal;

        private void LateUpdate()
        {
            LookAtTarget();
        }

        public override void LookAtTarget()
        {
            if (_useLocal)
            {
                transform.localEulerAngles = Target;
            }
            else
            {
                transform.eulerAngles = Target;
            }
        }
    }
}