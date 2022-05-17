using System;
using UnityEngine;

namespace Depra.UI.Runtime.PassiveViews.Billboards.Base
{
    [Serializable]
    public class BillboardParameters
    {
        [field: SerializeField] public Vector3 PositionOffset { get; private set; } = new(0f, 0.5f, 0f);
        [field: SerializeField] public Vector3 RotationOffset { get; set; }

        public void ApplyPositionOffset(Transform source, Vector3 targetPosition)
        {
            var positionWithOffset = targetPosition + PositionOffset;
            source.position = positionWithOffset;
        }

        public Quaternion ApplyRotationOffset(Transform source)
        {
            var rotation = source.rotation * Quaternion.identity * Quaternion.Euler(RotationOffset);
            return rotation;
        }
    }
}