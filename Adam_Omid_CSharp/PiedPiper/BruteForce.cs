using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PiedPiper
{
    // http://www.mathwarehouse.com/probability/permutations-repeated-items.php
    // TODO: Check for theoretical minimum, and see if we find that, then stop.

    public static class BruteForce
    {
        public static void Execute(int binSize, int[] pipes, bool printVerbose = false)
        {
            Console.WriteLine("Permutations to check: " + GetPermutationsCount(pipes).ToString("N0"));

            var packer = new Packer(binSize);

            // Pipes need to be ordered ascending for the next permutations generator to get the next solution.
            var pipesToTry = pipes.OrderBy(x => x).ToArray();

            List<Bin> currentSmallestPacks = null;
            var solutions = new int[pipes.Length];
            
            var stopwatch = Stopwatch.StartNew();

            var attemptCount = 0;

            do
            {
                var packedBins = packer.Pack(pipesToTry, false);

                solutions[packedBins.Count]++;

                if (printVerbose)
                {
                    PrintPackedBins(packedBins, pipesToTry);
                }

                if (IsBetterSolution(currentSmallestPacks, packedBins))
                {
                    currentSmallestPacks = packedBins;
                }

                attemptCount++;
                if (attemptCount % 100000 == 0)
                {
                    Console.WriteLine("Done: {0}", attemptCount.ToString("N0"));
                }
            } while (Permutation.NextPermutation(pipesToTry));

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("A Best Solution for pipes {0} and bin size {1}", String.Join(",", pipes), binSize);
            PrintSolutionsCount(solutions);
            PrintPackedBins(currentSmallestPacks, null);

            Console.WriteLine("Solutions tried: {0}, Duration {1}s:", attemptCount.ToString("N0"), stopwatch.Elapsed.TotalSeconds);
        }

        private static void PrintSolutionsCount(IEnumerable<int> solutions)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < solutions.Count(); i++)
            {
                sb.AppendFormat("({0}-{1})", i, solutions.ElementAt(i).ToString("N0"));
            }
            Console.WriteLine("Number of bin solution counts: {0}", sb);
        }

        private static bool IsBetterSolution(List<Bin> currentSmallestPacks, List<Bin> packedBins)
        {
            if (currentSmallestPacks == null)
            {
                return true;
            }
            if (currentSmallestPacks.Count == packedBins.Count)
            {
                return false;
            }
            if (currentSmallestPacks.Count > packedBins.Count)
            {
                return true;
            }
            return false;
        }

        private static void PrintPackedBins(List<Bin> packedBins, int[] pipes)
        {
            Console.WriteLine("Number of bins: " + packedBins.Count);

            if (pipes != null)
            {
                Console.WriteLine("Pipes to pack:  " + String.Join(",", pipes));
            }

            foreach (var packedBin in packedBins)
            {
                Console.WriteLine(packedBin.ToString());
            }
        }

        public static BigInteger GetPermutationsCount(int[] ints)
        {
            if (ints.Count() == 0)
            {
                return 0;
            }

            var groups = ints.GroupBy(i => i);

            var numerator = Factorial(ints.Count());

            var denominator =  new BigInteger(1);
            foreach (var @group in groups)
            {
                denominator *= Factorial(@group.Count());
            }

            return numerator/denominator;
        }

        public static BigInteger Factorial(BigInteger number)
        {
            var cumulator = new BigInteger(1);
            for (var i = 1; i <= number; i++)
            {
                cumulator *= i;
            }

            return cumulator;
        }
    }
}
