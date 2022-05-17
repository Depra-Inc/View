using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always face another object in your game.
    /// </summary>
    [ExecuteAlways]
    public class BillboardLookToTransform : Billboard<Transform>
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
            var targetRotation = _parameters.ApplyRotationOffset(Target.rotation);
            transform.rotation = targetRotation;
        }
    }
}