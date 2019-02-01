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
}
