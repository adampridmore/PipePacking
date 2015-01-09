using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class BruteForceTests
    {
        [TestMethod]
        public void No_Items_Permutations()
        {
            var count = BruteForce.GetPermutationsCount(new int[] {});

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Single_Item_Permutations()
        {
            var count = BruteForce.GetPermutationsCount(new[] {1});

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Large_List_Permutations()
        {
            var count = BruteForce.GetPermutationsCount(new[] { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 });

            Assert.AreEqual("302,702,400" , count.ToString("N0"));
        }

        [TestMethod]
        public void Large_List_Permutations_2()
        {
            var count = BruteForce.GetPermutationsCount(new[]
            {
                1,1,1,2,2,2,3,3,3,4,4,4,5,5,5,5
            });

            Console.WriteLine(count.ToString("N0"));
        }
        
        [TestMethod]
        public void Factorial()
        {
            Assert.AreEqual(1, BruteForce.Factorial(0));
            Assert.AreEqual(1, BruteForce.Factorial(1));
            Assert.AreEqual(2, BruteForce.Factorial(2));
            Assert.AreEqual(120, BruteForce.Factorial(5));
            Assert.AreEqual(3628800, BruteForce.Factorial(10));
            Assert.AreEqual(87178291200, BruteForce.Factorial(14));
        }
    }
}
