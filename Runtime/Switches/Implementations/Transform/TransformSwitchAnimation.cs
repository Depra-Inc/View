using System;
using UnityEngine;

namespace Depra.View.Runtime.Switches.Implementations.Transform
{
    using Transform = UnityEngine.Transform;

    [Serializable]
    public abstract class TransformSwitchAnimation : IDisposable
    {
        [SerializeField] private Vector3 _initialValue;

        protected Vector3 InitialValue => _initialValue;

        public abstract void Play(Transform target, Action onComplete = null);

        public abstract void Dispose();
    }
}