using Depra.View.Runtime.Billboards.Interfaces;
using Depra.View.Runtime.Billboards.Utils;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Abstract
{
    [ExecuteAlways]
    public class Billboard : MonoBehaviour, IBillboard
    {
        [SerializeReference, SubclassSelector] private IOrientationType _type;
        [SerializeField] private bool _useSafe = true;
        [SerializeField] private bool _toggleVisible = true;

        private void LateUpdate()
        {
            LookAtTarget();
        }

        public void LookAtTarget()
        {
            if (_useSafe)
            {
                _type.OrientSafely();
            }
            else
            {
                _type.Orient();
            }
        }
        
        [PublicAPI]
        public void Init<TSource, TTarget>(TSource source)
        {
            if (OrientationTypeResolver.TryResolveOrientationType<TSource, TTarget>(out var newType) == false)
            {
                return;
            }
            
            if (newType != _type)
            {
                newType.Init(source);
                _type = newType;
            }
                
            _type.Reset(gameObject);
        }

        private void OnBecameVisible()
        {
            if (_toggleVisible)
            {
                enabled = true;
            }
        }

        private void OnBecameInvisible()
        {
            if (_toggleVisible)
            {
                enabled = false;
            }
        }
        
        [Button]
        private void Reset()
        {
            _type.Reset(gameObject);
        }
    }
}