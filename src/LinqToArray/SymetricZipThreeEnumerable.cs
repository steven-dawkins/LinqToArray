using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{
    public class SymetricZipThreeEnumerable<T1, T2, T3, TOut> : IEnumerable<TOut>
    {
        private readonly IEnumerable<T1> _source1;
        private readonly IEnumerable<T2> _source2;
        private readonly IEnumerable<T3> _source3;
        private Func<T1, T2, T3, TOut> _resultSelector;

        public SymetricZipThreeEnumerable(T1[] source1, T2[] source2, T3[] source3, Func<T1, T2, T3, TOut> resultSelector)
        {
            if (source1.Length != source2.Length || source1.Length != source3.Length)
                throw new ArgumentException("SymetricZip requires that all source arrays have the same length");

            _source1 = new ArrayEnumerable<T1>(source1, 0, source1.Length - 1);
            _source2 = new ArrayEnumerable<T2>(source2, 0, source2.Length - 1);
            _source3 = new ArrayEnumerable<T3>(source3, 0, source3.Length - 1);
            _resultSelector = resultSelector;
        }

        private SymetricZipThreeEnumerable(IEnumerable<T1> source1, IEnumerable<T2> source2, IEnumerable<T3> source3, Func<T1, T2, T3, TOut> resultSelector)
        {
            _source1 = source1;
            _source2 = source2;
            _source3 = source3;
            _resultSelector = resultSelector;
        }

        private IEnumerable<TOut> Enumerate()
        {
            using(var e1 = _source1.GetEnumerator())
            using(var e2 = _source2.GetEnumerator())
            using (var e3 = _source3.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    yield return _resultSelector(e1.Current, e2.Current, e3.Current);
            }
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
            return new SymetricZipThreeEnumerable<T1, T2, T3, TOut>(_source1.Reverse(), _source2.Reverse(), _source3.Reverse(), _resultSelector);
        }

        public IEnumerable<TOut> Skip(int count)
        {
            return new SymetricZipThreeEnumerable<T1, T2, T3, TOut>(_source1.Skip(count), _source2.Skip(count), _source3.Skip(count), _resultSelector);
        }
    }
}
