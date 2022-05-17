using System;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force a non-physical object to always face the camera.
    /// </summary>
    [ExecuteAlways]
    public class BillboardLookToCamera : MonoBehaviour, IBillboard
    {
        [SerializeField] private BillboardParameters _parameters;
        [SerializeReference, SubclassSelector] private ICameraProvider _cameraProvider;

        private void Start()
        {
            Assert.IsNotNull(_cameraProvider);
        }

        private void LateUpdate()
        {
            if (_cameraProvider?.Camera)
            {
                LookAtTarget();
            }
        }

        public void LookAtTarget()
        {
            var currentRotation = _cameraProvider.Camera.transform.rotation;
            var targetRotation = _parameters.ApplyRotationOffset(currentRotation);
            transform.rotation = targetRotation;
        }

        private void Reset()
        {
            _cameraProvider = new CachedMainCamera();
        }
    }
}