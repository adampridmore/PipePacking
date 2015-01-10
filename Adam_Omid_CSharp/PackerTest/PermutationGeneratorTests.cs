using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    // http://www.mathwarehouse.com/probability/permutations-repeated-items.php
    [TestClass]
    public class PermutationGeneratorTests
    {
        [TestMethod]
        public void Number_of_solution_permutations_for_empty_list()
        {
            var permutation2 = new PermutationGenerator(new int[] { });

            Assert.IsNull(permutation2.TryGetNextPermutation());
        }

        [TestMethod]
        public void Number_of_solution_permutations_for_single_item()
        {
            var permutation2 = new PermutationGenerator(new [] {10});

            CollectionAssert.AreEqual(new[] {10}, permutation2.TryGetNextPermutation());

            Assert.IsNull(permutation2.TryGetNextPermutation());
        }

        [TestMethod]
        public void Duplicates_with_more_values()
        {
            var list = new[] { 1, 1, 2 };

            var permutation = new PermutationGenerator(list);
            
            var p1 = permutation.TryGetNextPermutation();
            var p2 = permutation.TryGetNextPermutation();
            var p3 = permutation.TryGetNextPermutation();

            Console.WriteLine("P1: " + String.Join(",", p1));
            Console.WriteLine("P2: " + String.Join(",", p2));
            Console.WriteLine("P3: " + String.Join(",", p3));

            CollectionAssert.AreEqual(new[] { 1, 1, 2 }, p1);
            CollectionAssert.AreEqual(new[] { 1, 2, 1 }, p2);
            CollectionAssert.AreEqual(new[] { 2, 1, 1 }, p3);

            Assert.IsNull(permutation.TryGetNextPermutation());
        }

        [TestMethod]
        public void Has_Next()
        {
            var list = new[] { 1, 2 };

            var permutation = new PermutationGenerator(list);

            Assert.IsTrue(permutation.HasNext());
            permutation.TryGetNextPermutation();

            Assert.IsTrue(permutation.HasNext());
            permutation.TryGetNextPermutation();

            Assert.IsNull(permutation.TryGetNextPermutation());
            Assert.IsFalse(permutation.HasNext());
        }
    }
}
