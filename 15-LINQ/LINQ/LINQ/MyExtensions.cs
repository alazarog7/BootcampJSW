using System;
using System.Collections;
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

        private static T MedianX<T>(this IEnumerable<T> sequence)
        {
            var ordered = sequence.OrderBy(item => item);

            int middlePosition = ordered.Count() / 2;

            return ordered.ElementAt(middlePosition);
        }

        public static V Median<T,V>(this IEnumerable<T> sequence, Func<T,V> selector)
        {
            return sequence.Select(selector).MedianX();
        }

        public static V Mode<T,V>(this IEnumerable<T> sequence, Func<T, V> selector)
        {
            var result = sequence
                .Select(selector)
                .GroupBy(n => n)
                .OrderByDescending(e => e.Count())
                .FirstOrDefault();
            
            return result.Key;
        }

        public static V UnMode<T,V>(this IEnumerable<T> sequence, Func<T, V> selector)
        {
            var result = sequence
                .Select(selector)
                .GroupBy(n => n)
                .OrderBy(e => e.Count())
                .FirstOrDefault();

            return result.Key;
        }
    }
}


