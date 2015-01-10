using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    // http://www.mathwarehouse.com/probability/permutations-repeated-items.php
    [TestClass]
    public class PermutationsTests
    {
        [TestMethod]
        public void Number_of_solution_permutations_for_empty_list()
        {
            var count = Permutation.GetPermutationsCount(new int[] { });

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Number_of_solution_permutations_for_single_item()
        {
            var count = Permutation.GetPermutationsCount(new[] { 1 });

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Permutation_GetEnumerator()
        {
            var list = new[] { 1, 2 };

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(2, results.Count);
            CollectionAssert.AreEqual(new[] { 1, 2 }, results[0]);
            CollectionAssert.AreEqual(new[] { 2, 1 }, results[1]);
        }

        [TestMethod]
        public void Permutation_GetEnumerator_In_Different_Order()
        {
            var list = new[] { 2 ,1};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(2, results.Count);
            CollectionAssert.AreEqual(new[] { 1, 2 }, results[0]);
            CollectionAssert.AreEqual(new[] { 2, 1 }, results[1]);
        }

        [TestMethod]
        public void Duplicates()
        {
            var list = new[] { 1, 1};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(1, results.Count);
            CollectionAssert.AreEqual(new[] { 1, 1 }, results[0]);
        }

        [TestMethod]
        public void Duplicates_with_more_values()
        {
            var list = new[] { 1, 1, 2};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(3, results.Count);
            CollectionAssert.AreEqual(new[] { 1, 1 ,2}, results[0]);
            CollectionAssert.AreEqual(new[] { 1, 2, 1 }, results[1]);
            CollectionAssert.AreEqual(new[] { 2, 1, 1 }, results[2]);
        }
        
        [TestMethod]
        public void Number_of_solution_permutations_for_large_list()
        {
            var count = Permutation.GetPermutationsCount(new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 });

            Assert.AreEqual("302,702,400", count.ToString("N0"));
        }

        [TestMethod]
        public void Threads()
        {
            //var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 };
//            var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8,9};
            var pipes = new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8};

            var count = 0;
            
            Console.WriteLine(Permutation.GetPermutationsCount(pipes));

            Parallel.ForEach(Permutation.GetPermutations(pipes), delegate(int[] pipePermutation)
            {
                Interlocked.Increment(ref count);
//                if (count%100000 == 0)
//                {
//                    System.Diagnostics.Debug.WriteLine(count);
////                    Console.WriteLine(count.ToString("N0"));
//                }
            });

            Console.WriteLine(count);

            //Assert.AreEqual("302,702,400", count.ToString("N0"));
        }
    }
}
