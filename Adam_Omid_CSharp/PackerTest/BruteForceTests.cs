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
        public void Number_of_solution_permutations_for_empty_list()
        {
            var count = BruteForce.GetPermutationsCount(new int[] {});

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Number_of_solution_permutations_for_single_item()
        {
            var count = BruteForce.GetPermutationsCount(new[] {1});

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Number_of_solution_permutations_for_large_list()
        {
            var count = BruteForce.GetPermutationsCount(new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 });

            Assert.AreEqual("302,702,400" , count.ToString("N0"));
        }

        [TestMethod]
        public void Brute_force_for_empty_pipes()
        {
            var pipes = new int[] {};

            var result = BruteForce.Execute2(10, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(0, result.MinimumNumberOfBinsRequired);
            Assert.AreEqual(1, result.SolutionsCounts.Count());
            Assert.AreEqual(1, result.SolutionsCounts[0]);
        }

        [TestMethod]
        public void Brute_force_for_simple_pipes()
        {
            var pipes = new [] {5,6};

            var result = BruteForce.Execute2(6, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(2, result.MinimumNumberOfBinsRequired);
        }

        [TestMethod]
        public void Brute_force_for_complex_pipes()
        {
            var pipes = new[] { 3,3,3,2,4,5};

            var result = BruteForce.Execute2(10, pipes);

            Console.WriteLine(result);

            Assert.AreEqual(2, result.MinimumNumberOfBinsRequired);
        }
    }
}
