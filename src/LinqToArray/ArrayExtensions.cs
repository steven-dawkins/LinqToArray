using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{
    public static class ArrayExtensions
    {
        public static ArrayEnumerable<T> Reverse<T>(this T[] source)
        {
            return new ArrayEnumerable<T>(source, source.Length - 1, 0);
        }

        public static ArrayEnumerable<T> Skip<T>(this T[] source, int count)
        {
            return new ArrayEnumerable<T>(source, count, source.Length - 1);
        }

        public static SymetricZipTwoEnumerable<T1, T2, TOut> SymetricZip<T1, T2, TOut>(this T1[] source1, T2[] source2, Func<T1, T2, TOut> resultSelector)
        {
            return new SymetricZipTwoEnumerable<T1, T2, TOut>(source1, source2, resultSelector);
        }

        public static SymetricZipThreeEnumerable<T1, T2, T3, TOut> SymetricZip<T1, T2, T3, TOut>(this T1[] source1, T2[] source2, T3[] source3, Func<T1, T2, T3, TOut> resultSelector)
        {
            return new SymetricZipThreeEnumerable<T1, T2, T3, TOut>(source1, source2, source3, resultSelector);
        }

    }
}
