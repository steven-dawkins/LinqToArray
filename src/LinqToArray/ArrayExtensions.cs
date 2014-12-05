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
    }
}
