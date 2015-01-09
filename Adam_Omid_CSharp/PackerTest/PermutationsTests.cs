using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class PermutationsTests
    {
//        [TestMethod]
//        public void GetPowerSetTest()
//        {
//            var list = new List<int> {1,2,3,4,5,6,7,8};
//
//            var set = GetPowerSet(list);
//
//            var sb = new StringBuilder();
//
//            foreach (var combination in set)
//            {
//                sb.AppendLine(String.Join(",", combination));
//            }
//
//            Console.WriteLine(sb.ToString());
//        }
//
//        public IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
//        {
//            return from m in Enumerable.Range(0, 1 << list.Count)
//                   select
//                       from i in Enumerable.Range(0, list.Count)
//                       where (m & (1 << i)) != 0
//                       select list[i];
//        }

        [TestMethod]
        public void SingleItemInList()
        {
            var list = new [] { 1, 2, 3};

            do
            {
                Console.WriteLine(String.Join(",", list));
            } while (Permutation.NextPermutation(list));
        }

        [TestMethod]
        public void LargeList()
        {
            var list = new[] { 7, 2, 2, 3, 3, 3 };

            do
            {
                Console.WriteLine(String.Join(",", list));
            } while (Permutation.NextPermutation(list));
        }
    }
}
