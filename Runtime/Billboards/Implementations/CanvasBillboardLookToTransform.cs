using Depra.View.Runtime.Billboards.Abstract;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force the UI canvas to always face the camera.
    /// </summary>
    [ExecuteAlways]
    public class CanvasBillboardLookToTransform : Billboard<Transform>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeReference, SubclassSelector] private ICameraProvider _cameraProvider;
        
        [SerializeField] private bool _destroyOnEmptyTarget;
        [SerializeField] private BillboardParameters _parameters;

        private Transform _transform;

        private void Awake()
        {
            Assert.IsNotNull(_canvas);
            
            _canvas.worldCamera = _cameraProvider.Camera;
            _transform = _canvas.transform;
            _transform.SetParent(_cameraProvider.Camera.transform);
        }

        private void LateUpdate()
        {
            if (Target == null || _transform == null)
            {
                OnTargetNotFound();
                return;
            }

            LookAtTarget();
        }

        public override void LookAtTarget()
        {
            _transform.position = _parameters.ApplyRotationOffset(Target.position);
        }

        private void OnTargetNotFound()
        {
            if (_destroyOnEmptyTarget == false && Application.isPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                enabled = false;
            }
        }

        private void OnBecameVisible() => enabled = true;

        private void OnBecameInvisible() => enabled = false;

        private void Reset()
        {
            _canvas = GetComponent<Canvas>();
            _cameraProvider = new CachedMainCamera();
        }
    }
}