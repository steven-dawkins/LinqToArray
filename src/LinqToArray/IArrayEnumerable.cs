using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{
    public class IArrayEnumerable<T> : IEnumerable<T>
    {
        private readonly T[] source;
        private readonly int end;
        private readonly int start;

        public IArrayEnumerable(T[] source, int start, int end)
        {
            this.source = source;
            this.start = start;
            this.end = end;
        }

        private IEnumerable<T> Enumerate()
        {
            if (this.start < this.end)
            {
                for (int index = this.start; index <= this.end && index < source.Length; index++)
                {
                    yield return this.source[index];
                }
            }
            else
            {
                for (int index = this.start; index >= this.end && index >= 0; index--)
                {
                    yield return this.source[index];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        public IArrayEnumerable<T> Reverse()
        {
            return new IArrayEnumerable<T>(this.source, this.end, this.start);
        }

        public IArrayEnumerable<T> Skip(int amount)
        {
            return new IArrayEnumerable<T>(this.source, this.start + amount * Direction, this.end);
        }

        public IArrayEnumerable<T> Take(int amount)
        {
            return new IArrayEnumerable<T>(this.source, this.start, this.start + (amount - 1) * Direction);
        }

        private int Direction
        {
            get { return start < end ? 1 : -1; }
        }
    }
}
