using Depra.UI.Runtime.PassiveViews.Billboards.Base;
using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [ExecuteAlways]
    public class TransformBillboard : Billboard<Transform>
    {
        [SerializeField] private BillboardParameters _parameters;

        private void LateUpdate()
        {
            if (Target)
            {
                LookAtTarget();
            }
        }

        public override void LookAtTarget()
        {
            var rotation = _parameters.ApplyRotationOffset(Target);
            transform.rotation = rotation;
        }
    }
}