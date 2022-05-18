using System;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [Serializable]
    public class RotationAxisData
    {
        [field: SerializeField] public Vector3 Axis { get; private set; }

        public Quaternion Combine(Quaternion rotation)
        {
            var newRotation = rotation * Quaternion.identity * Quaternion.Euler(Axis);
            return newRotation;
        }

        public RotationAxisData()
        {
        }

        public RotationAxisData(Vector3 axis)
        {
            Axis = axis;
        }
    }
}