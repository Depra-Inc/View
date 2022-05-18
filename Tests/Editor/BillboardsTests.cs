using Depra.View.Runtime.Billboards.Utils;
using NUnit.Framework;
using UnityEngine;

namespace Depra.View.Tests.Editor
{
    public class BillboardsTests
    {
        [Test]
        public void Can_Resolve_Orientation_Type()
        {
            OrientationTypeResolver.ResolveOrientationType<Transform, Transform>();
        }
    }
}
