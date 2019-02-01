using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace FibonacciUnitTests
{
    public class Fibonacci
    {
        /// <summary>
        /// Cache used for Memoization purpose
        /// </summary>
        static Dictionary<int, int> _cache = new Dictionary<int, int>();

        /// <summary>
        /// Precompute cache, dynamic programming method
        /// </summary>
        /// <param name="n"></param>
        public static void PreComputeCache(int n)
        {
            _cache.Clear();
            _cache[0] = 0;
            _cache[1] = 1;
            for(var i = 2; i < n; i++)
            {
                _cache[i] = _cache[i-1] + _cache[i-2];
            }
        }

        public static int Compute(int n)
        {
            if(_cache.ContainsKey(n))
            {
                Debug.WriteLine($"Cache {n} = {_cache[n]}");
                return _cache[n];
            }

            var r = 0;

            if (n == 0) r = 0;
            else if (n == 1) r = 1;
            else r = Compute(n - 1) + Compute(n - 2);

            _cache.Add(n, r);
            return r;
        }
    }

    [TestClass]
    public class FibonacciUnitTest
    {
        static List<int> FibonacciSequenceExpected = new List<int>() { 
            0,1,1,2,3,5,8,13,21,34,55,89,144
        };

        [TestMethod]
        public void Compute0And1()
        {
            Assert.AreEqual(0, Fibonacci.Compute(0));
            Assert.AreEqual(1, Fibonacci.Compute(1));
        }

        [TestMethod]
        public void ComputeFirst1And2Numbers()
        {
            for(var i = 0; i < FibonacciSequenceExpected.Count; i++)
            {
                Assert.AreEqual(FibonacciSequenceExpected[i], Fibonacci.Compute(i));
            }
        }

        [TestMethod]
        public void ComputeFirst12Numbers_DynamicProgramming()
        {
            Fibonacci.PreComputeCache(FibonacciSequenceExpected.Count);

            for (var i = 0; i < FibonacciSequenceExpected.Count; i++)
            {
                Assert.AreEqual(FibonacciSequenceExpected[i], Fibonacci.Compute(i));
            }
        }
    }
}
