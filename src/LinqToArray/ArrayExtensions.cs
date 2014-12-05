using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{
    public static class ArrayExtensions
    {
        public static IArrayEnumerable<T> Reverse<T>(this T[] source)
        {
            return new IArrayEnumerable<T>(source, source.Length - 1, 0);
        }
    }
}
