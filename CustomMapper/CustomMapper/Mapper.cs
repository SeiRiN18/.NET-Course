using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapFunc = MapperConfig.Get<TSource, TDestination>();
            return mapFunc(source);
        }
    }
}
