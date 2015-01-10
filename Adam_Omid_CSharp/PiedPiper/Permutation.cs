using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace PiedPiper
{
    public static class Permutation
    {
        public static IEnumerable<int[]> GetPermutations(IEnumerable<int> list)
        {
            var permutationGenerator = new PermutationGenerator(list);

            while (permutationGenerator.HasNext())
            {
                yield return permutationGenerator.TryGetNextPermutation();
            }
        }

        // From: http://www.mathwarehouse.com/probability/permutations-repeated-items.php
        public static BigInteger GetPermutationsCount(IList<int> ints)
        {
            if (!ints.Any())
            {
                return 0;
            }

            var groups = ints.GroupBy(i => i);

            var numerator = new BigInteger(ints.Count()).Factorial();

            var denominator = new BigInteger(1);
            foreach (var @group in groups)
            {
                denominator *= new BigInteger(@group.Count()).Factorial();
            }

            return numerator / denominator;
        }
    }
}
