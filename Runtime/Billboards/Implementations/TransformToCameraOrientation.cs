using System;
using Depra.View.Runtime.Billboards.Abstract;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always face the camera.
    /// </summary>
    [Serializable]
    [AddTypeMenu("Transform To Camera")]
    public class TransformToCameraOrientation : OrientationType<Transform, Camera>
    {
        [SerializeField] private Transform _source;
        [SerializeReference, SubclassSelector] private ICameraProvider _cameraProvider;
        [SerializeField] private RotationAxisData _availableAxis;

        protected override Transform Source => _source;
        protected override Camera Target => _cameraProvider?.Camera;

        public override void Orient()
        {
            var newRotation = _availableAxis.Combine(Target.transform.rotation);
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
            _cameraProvider ??= new CachedMainCamera();
        }
    }
}