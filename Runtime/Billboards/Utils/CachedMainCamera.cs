using System;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Utils
{
    public class CachedMainCamera
    {
        private Camera _worldCamera;

        public Camera Value
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
                    throw new NullReferenceException();
                }

                return _worldCamera;
            }
        }
    }
}