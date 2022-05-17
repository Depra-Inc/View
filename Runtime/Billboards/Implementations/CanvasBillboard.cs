using Depra.UI.Runtime.PassiveViews.Billboards.Base;
using Depra.View.Runtime.Billboards.Abstract;
using Depra.View.Runtime.Billboards.Utils;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [ExecuteAlways]
    [RequireComponent(typeof(Canvas))]
    public class CanvasBillboard : Billboard<Transform>
    {
        [SerializeField] private BillboardParameters _parameters;

        private Canvas _canvas;
        private readonly CachedMainCamera _camera = new();

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = _camera.Value;
            
            transform.SetParent(_camera.Value.transform);
        }

        private void LateUpdate()
        {
            if (TryLookAtTarget() == false)
            {
                Destroy(gameObject);
            }
        }

        public override void LookAtTarget()
        {
            _parameters.ApplyPositionOffset(transform, Target.position);
        }
        
        private bool TryLookAtTarget()
        {
            if (Target == null)
            {
                return false;
            }

            LookAtTarget();
            return true;
        }

        private void OnBecameVisible() => enabled = true;

        private void OnBecameInvisible() => enabled = false;
    }
}