using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Depra.View.Runtime.Billboards.Abstract;
using Depra.View.Runtime.Billboards.Interfaces;

[assembly: InternalsVisibleTo("Depra.View.Tests.Editor")]

namespace Depra.View.Runtime.Billboards.Utils
{
    public static class OrientationTypeResolver
    {
        public static bool TryResolveOrientationType<TSource, TTarget>(
            out OrientationType<TSource, TTarget> orientationType)
        {
            try
            {
                orientationType = ResolveOrientationType<TSource, TTarget>();
                return true;
            }
            catch
            {
                orientationType = null;
                return false;
            }
        }

        internal static OrientationType<TSource, TTarget> ResolveOrientationType<TSource, TTarget>()
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            var assembly = Assembly.GetExecutingAssembly();
            var allTypes = assembly.GetTypes();
            var allOrientationTypes = allTypes
                .Where(type => type.IsAbstract == false && type.GetInterfaces()
                    .Any(@interface => @interface == typeof(IOrientationType)));

            if (allOrientationTypes == null)
            {
                throw new Exception("Orientation types not found!");
            }

            var resolvedType = allOrientationTypes.FirstOrDefault(type =>
                type.BaseType is { IsGenericType: true } && 
                type.BaseType.GetGenericArguments()[0] == sourceType &&
                type.BaseType.GetGenericArguments()[1] == targetType);

            if (resolvedType == null)
            {
                throw new Exception("Base type not found!");
            }

            var resolvedClass = (OrientationType<TSource, TTarget>)Activator.CreateInstance(resolvedType);

            return resolvedClass;
        }
    }
}