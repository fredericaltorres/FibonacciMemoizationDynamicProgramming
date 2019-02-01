using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FibonacciUnitTests
{
    [TestClass]
    public class FibonacciUnitTest
    {
        static List<int> FibonacciSequenceExpected = new List<int>()
        { 
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
