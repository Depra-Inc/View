using System.Diagnostics.CodeAnalysis;
using Depra.View.Runtime.Billboards.Interfaces;
using UnityEngine;

namespace Depra.View.Runtime.Billboards.Abstract
{
    public abstract class OrientationType<TSource, TTarget> : IOrientationType
    {
        protected abstract TSource Source { get; }
        protected abstract TTarget Target { get; }

        public abstract void Orient();

        public abstract void OrientSafely();

        public abstract void Init([NotNull] TSource source);

        public virtual void Reset(GameObject user)
        {
        }
    }
}