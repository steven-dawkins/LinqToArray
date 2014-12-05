using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{
    public class SymetricZipTwoEnumerable<T1, T2, TOut> : IEnumerable<TOut>
    {
        private readonly IEnumerable<T1> _source1;
        private readonly IEnumerable<T2> _source2;
        private Func<T1, T2, TOut> _resultSelector;

        public SymetricZipTwoEnumerable(T1[] source1, T2[] source2, Func<T1, T2, TOut> resultSelector)
        {
            if (source1.Length != source2.Length)
                throw new ArgumentException("SymetricZip requires that both source arrays have the same length");

            _source1 = new ArrayEnumerable<T1>(source1, 0, source1.Length - 1);
            _source2 = new ArrayEnumerable<T2>(source2, 0, source2.Length - 1);
            _resultSelector = resultSelector;
        }

        private SymetricZipTwoEnumerable(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, TOut> resultSelector)
        {
            _source1 = source1;
            _source2 = source2;
            _resultSelector = resultSelector;
        }

        private IEnumerable<TOut> Enumerate()
        {
            return Enumerable.Zip(_source1, _source2, _resultSelector);
        }

        public IEnumerator<TOut> GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        public IEnumerable<TOut> Reverse()
        {
            return new SymetricZipTwoEnumerable<T1, T2, TOut>(_source1.Reverse(), _source2.Reverse(), _resultSelector);
        }

        public IEnumerable<TOut> Skip(int count)
        {
            return new SymetricZipTwoEnumerable<T1, T2, TOut>(_source1.Skip(count), _source2.Skip(count), _resultSelector);
        }
    }
}
