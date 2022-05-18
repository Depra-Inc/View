using System;
using Depra.View.Runtime.Billboards.Abstract;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.View.Runtime.Billboards.Implementations
{
    /// <summary>
    /// Use to force the UI canvas to always face the camera.
    /// </summary>
    [Serializable]
    [AddTypeMenu("Canvas To Transform")]
    public class CanvasToTransformOrientation : OrientationType<Canvas, Transform>
    {
        [SerializeField] private Canvas _source;
        [SerializeField] private Transform _target;
        [SerializeReference, SubclassSelector] private ICameraProvider _cameraProvider;
        [SerializeField] private PositionOffsetData _positionOffset;

        protected override Canvas Source => _source;
        protected override Transform Target => _target;

        public override void Orient()
        {
            var targetPositionWithOffset = _positionOffset.Combine(Target.position);
            Source.transform.position = targetPositionWithOffset;
        }

        public override void OrientSafely()
        {
            if (Target)
            {
                Orient();
            }
        }

        public override void Init(Canvas source)
        {
            Assert.IsNotNull(source);

            _source = source;
            Prepare();
        }

        private void Prepare()
        {
            Source.renderMode = RenderMode.WorldSpace;
            Source.worldCamera = _cameraProvider.Camera;
            Source.transform.SetParent(_cameraProvider.Camera.transform);
        }

        public override void Reset(GameObject user)
        {
            _source ??= user.GetComponent<Canvas>();
            _cameraProvider ??= new CachedMainCamera();
            _positionOffset = new PositionOffsetData();

            Prepare();
        }
    }
}