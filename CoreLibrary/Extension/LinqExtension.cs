using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLearning.CoreLibrary.Extension
{
    public static class LinqExtension
    {
        public static IEnumerable<U> TypeSelect<U>(this IEnumerable<dynamic> source)
        {
            return source.Where(item => item is U).Select(item => (U)item);
        }


        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source ?? Enumerable.Empty<T>())action?.Invoke(item);
        }
    }
}
