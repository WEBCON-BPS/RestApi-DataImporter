using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace WEBCON.BPS.Importer.Helpers
{
    public static class GeneralHelper
    {
        public static IEnumerable<T> DistinctBy<T>(this IEnumerable<T> enumerable, Func<T, object> propertySelector) 
            => enumerable.GroupBy(propertySelector).Select(x => x.First());

        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
                @this.Add(element);
        }
    }
}
