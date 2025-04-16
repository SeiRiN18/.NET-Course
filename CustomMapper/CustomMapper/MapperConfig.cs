using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    public static class MapperConfig
    {
        private static Dictionary<(Type Source, Type Destination), Delegate> _mappings = new();

        public static void Register<Tsource, TDestination>(Func<Tsource, TDestination> mapFunc)
        {
            _mappings[(typeof(Tsource), typeof(TDestination))] = mapFunc;
        }
        public static Func<TSource, TDestination> Get<TSource, TDestination>()
        {
            if (_mappings.TryGetValue((typeof(TSource), typeof(TDestination)), out var mapFunc))
            {
                return (Func<TSource, TDestination>)mapFunc;
            }

            throw new InvalidOperationException($"Mapping from {typeof(TSource)} to {typeof(TDestination)} is not registered.");
        }
    }
}
