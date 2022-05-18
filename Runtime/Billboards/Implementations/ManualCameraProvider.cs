using System;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [Serializable]
    [AddTypeMenu("Manual")]
    public class ManualCameraProvider : ICameraProvider
    {
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}