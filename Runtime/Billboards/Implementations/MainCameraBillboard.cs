using Depra.UI.Runtime.PassiveViews.Billboards.Base;
using Depra.View.Runtime.Billboards.Interfaces;
using Depra.View.Runtime.Billboards.Utils;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [ExecuteAlways]
    public class MainCameraBillboard : MonoBehaviour, IBillboard
    {
        [SerializeField] private BillboardParameters _parameters;
        
        private readonly CachedMainCamera _mainCamera = new();

        private void LateUpdate()
        {
            if (_mainCamera?.Value)
            {
                LookAtTarget();
            }
        }

        public void LookAtTarget()
        {
            var rotation = _parameters.ApplyRotationOffset(_mainCamera.Value.transform);
            transform.rotation = rotation;
        }
    }
}