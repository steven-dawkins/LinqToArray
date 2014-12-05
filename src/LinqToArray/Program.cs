using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToArray
{        
    class Program
    {
        static void Main(string[] args)
        {
            int size = 1000000;
            {
                var testArray = Enumerable.Range(0, size).ToArray().AsEnumerable();

                var timer = new Stopwatch();
                timer.Start();

                var f = 0.0d;
                for (int i = 0; i < 1000; i++)
                {
                    var t = testArray.Reverse().Skip(size / 2).Take(10);

                    f += t.Sum() / (double)size;
                }

                Console.WriteLine("The slow result is: {0} in {1}ms", f, timer.ElapsedMilliseconds);
            }

            {
                var testArray = Enumerable.Range(0, size).ToArray();

                var timer = new Stopwatch();
                timer.Start();

                var f = 0.0d;
                for (int i = 0; i < 1000; i++)
                {
                    var t = testArray.Reverse().Skip(size/2).Take(10);

                    f += t.Sum() / (double)size;
                }

                Console.WriteLine("The fast result is: {0} in {1}ms", f, timer.ElapsedMilliseconds);                
            }

            Console.ReadKey();
        }
    }
}
