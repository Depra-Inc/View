using System;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [Serializable]
    public class BillboardParameters
    {
        [field: SerializeField] public Vector3 PositionOffset { get; private set; }
        [field: SerializeField] public Vector3 RotationOffset { get; private set; }

        public Vector3 ApplyRotationOffset(Vector3 sourcePosition)
        {
            var positionWithOffset = sourcePosition + PositionOffset;
            return positionWithOffset;
        }

        public Quaternion ApplyRotationOffset(Quaternion sourceRotation)
        {
            var rotation = sourceRotation * Quaternion.identity * Quaternion.Euler(RotationOffset);
            return rotation;
        }

        public BillboardParameters()
        {
            PositionOffset = Default.PositionOffset;
            RotationOffset = Default.RotationOffset;
        }

        public BillboardParameters(Vector3 positionOffset, Vector3 rotationOffset)
        {
            PositionOffset = positionOffset;
            RotationOffset = rotationOffset;
        }

        internal static BillboardParameters Default = new(new Vector3(0f, 0.5f, 0f), new Vector3());
    }
}