using System;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Implementations
{
    [Serializable]
    [AddTypeMenu("Main Camera")]
    public class CachedMainCamera : ICameraProvider
    {
        private Camera _worldCamera;

        public Camera Camera
        {
            get
            {
                if (_worldCamera)
                {
                    return _worldCamera;
                }
                
                _worldCamera = Camera.main;
                if (_worldCamera == null)
                {
                    throw new NullReferenceException("No camera found with tag 'MainCamera'!");
                }

                return _worldCamera;
            }
        }
    }
}