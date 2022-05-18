using System;
using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always be rotated by angles.
    /// </summary>
    [Serializable]
    [AddTypeMenu("Transform To Angles")]
    public class TransformToAnglesOrientation : OrientationType<Transform, Vector3>
    {
        [SerializeField] private Transform _source;
        [SerializeField] private Vector3 _angles;
        [SerializeField] private bool _useLocal;

        protected override Transform Source => _source;
        protected override Vector3 Target => _angles;

        public override void Orient()
        {
            if (_useLocal)
            {
                Source.localEulerAngles = Target;
            }
            else
            {
                Source.eulerAngles = Target;
            }
        }

        public override void OrientSafely() => Orient();
        
        public override void Init(Transform source)
        {
            Assert.IsNotNull(source);
            
            _source = source;
        }

        public override void Reset(GameObject user)
        {
            _source ??= user.transform;
        }
    }
}