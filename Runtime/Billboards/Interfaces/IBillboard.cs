using JetBrains.Annotations;

namespace Depra.View.Runtime.Billboards.Interfaces
{
    [PublicAPI]
    public interface IBillboard
    {
        void LookAtTarget();
    }
}