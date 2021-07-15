using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class MyExtensions
    {
        public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
        {
            return sequence;
        }

        private static int? Median(this IEnumerable<int?> sequence)
        {
            var ordered = sequence.OrderBy(item => item);

            int middlePosition = ordered.Count() / 2;

            return ordered.ElementAt(middlePosition);
        }

        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }

        public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            var result = sequence
                .Select(selector)
                .GroupBy(n => n)
                .OrderByDescending(e => e.ToList().Count())
                .FirstOrDefault();
            
            return result.Key;
        }

        public static int? UnMode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            var result = sequence
                .Select(selector)
                .GroupBy(n => n)
                .OrderBy(e => e.ToList().Count())
                .FirstOrDefault();

            return result.Key;
        }
    }
}
