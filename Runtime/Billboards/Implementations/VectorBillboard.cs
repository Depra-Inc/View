using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Uses direction as target.
    /// </summary>
    [ExecuteAlways]
    public class VectorBillboard : Billboard<Vector3>
    {
        private void LateUpdate()
        {
            LookAtTarget();
        }

        public override void LookAtTarget()
        {
            transform.eulerAngles = Target;
        }
    }
}