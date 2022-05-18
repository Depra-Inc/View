using System;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [Serializable]
    public class PositionOffsetData
    {
        [field: SerializeField] public Vector3 Offset { get; private set; }

        public Vector3 Combine(Vector3 position)
        {
            var positionWithOffset = position + Offset;
            return positionWithOffset;
        }

        public PositionOffsetData()
        {
        }

        public PositionOffsetData(Vector3 offset)
        {
            Offset = offset;
        }
    }
}