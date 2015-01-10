using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    // http://www.mathwarehouse.com/probability/permutations-repeated-items.php
    [TestClass]
    public class PermutationsTests
    {
        [TestMethod]
        public void Permutation_GetEnumerator()
        {
            var list = new[] { 1, 2 };

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(2, results.Count);
            CollectionAssert.AreEquivalent(new[] {1, 2}, results[0]);
            CollectionAssert.AreEquivalent(new[] { 2, 1 }, results[1]);
        }

        [TestMethod]
        public void Permutation_GetEnumerator_In_Different_Order()
        {
            var list = new[] { 2 ,1};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(2, results.Count);
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, results[0]);
            CollectionAssert.AreEquivalent(new[] { 2, 1 }, results[1]);
        }

        [TestMethod]
        public void Duplicates()
        {
            var list = new[] { 1, 1};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(1, results.Count);
            CollectionAssert.AreEquivalent(new[] { 1, 1 }, results[0]);
        }

        [TestMethod]
        public void Duplicates_with_more_values()
        {
            var list = new[] { 1, 1, 2};

            var results = Permutation.GetPermutations(list).ToList();

            Assert.AreEqual(3, results.Count);
            CollectionAssert.AreEquivalent(new[] { 1, 1 ,2}, results[0]);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 1 }, results[0]);
            CollectionAssert.AreEquivalent(new[] { 2, 1, 1 }, results[0]);
        }

    }
}
