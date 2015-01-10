using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class BruteForceTests
    {
        [TestMethod]
        public void Brute_force_for_empty_pipes()
        {
            var pipes = new int[] { };

            var result = BruteForce.Execute(10, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(0, result.MinimumNumberOfBinsRequired);
            Assert.AreEqual(1, result.SolutionsCounts.Count());
            Assert.AreEqual(0, result.SolutionsCounts[0]);
        }

        [TestMethod]
        public void Brute_force_for_simple_pipes()
        {
            var pipes = new[] { 5, 6 };

            var result = BruteForce.Execute(6, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(2, result.MinimumNumberOfBinsRequired);
        }

        [TestMethod]
        public void Brute_force_for_complex_pipes()
        {
            var pipes = new[] { 3, 3, 3, 2, 4, 5 };

            var result = BruteForce.Execute(10, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(2, result.MinimumNumberOfBinsRequired);
        }
    }
}
