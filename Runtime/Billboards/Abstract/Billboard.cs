using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Abstract
{
    public abstract class Billboard<T> : MonoBehaviour, IBillboard
    {
        [SerializeField] private T _target;

        protected T Target => _target;

        public abstract void LookAtTarget();
    }
}