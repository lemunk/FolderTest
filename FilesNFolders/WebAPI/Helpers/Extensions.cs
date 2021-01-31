using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Helpers
{
    public static class Extensions
    {
        //test notes:  got this recursive extension on stack, although works, the concat seems clunky and possible performance issue.
        public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            var result = source.SelectMany(selector);
            if (!result.Any())
            {
                return result;
            }
            return result.Concat(result.SelectManyRecursive(selector));
        }
    }
}
