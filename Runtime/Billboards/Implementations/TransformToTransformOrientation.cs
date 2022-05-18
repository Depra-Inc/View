using System;
using Depra.View.Runtime.Billboards.Abstract;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always face another object in your game.
    /// </summary>
    [Serializable]
    [AddTypeMenu("Transform To Transform")]
    public class TransformToTransformOrientation : OrientationType<Transform, Transform>
    {
        [SerializeField] private Transform _source;
        [SerializeField] private Transform _target;
        [SerializeField] private RotationAxisData _availableAxis;

        protected override Transform Source => _source;
        protected override Transform Target => _target;
        
        public override void Orient()
        {
            var newRotation = _availableAxis.Combine(Target.rotation);
            Source.rotation = newRotation;
        }

        public override void OrientSafely()
        {
            if (Target)
            {
                Orient();
            }
        }
        
        public override void Init(Transform source)
        {
            Assert.IsNotNull(source);
            
            _source = source;
        }

        public override void Reset(GameObject user)
        {
            _source ??= user.transform;
            _availableAxis = new RotationAxisData();
        }
    }
}