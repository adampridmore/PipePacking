using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PiedPiper
{
    public static class BruteForce
    {
        public static void Execute(int binSize, IList<int> pipes, bool printVerbose = false)
        {
            Console.WriteLine("Permutations to check: " + GetPermutationsCount(pipes.ToList()).ToString("N0"));

            var packer = new Packer(binSize);
            
            List<Bin> currentSmallestPacks = null;
            var solutions = new int[pipes.Count()];
            
            var stopwatch = Stopwatch.StartNew();

            var attemptCount = 0;

            foreach (var pipePermtation in Permutation.GetPermutations(pipes))
            {
                var packedBins = packer.Pack(pipePermtation, false);

                solutions[packedBins.Count]++;

                if (printVerbose)
                {
                    PrintPackedBins(packedBins, pipePermtation);
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
            }
            
            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("A Best Solution for pipes {0} and bin size {1}", String.Join(",", pipes), binSize);
            PrintSolutionsCount(solutions);
            PrintPackedBins(currentSmallestPacks, null);

            Console.WriteLine("Solutions tried: {0}, Duration {1}s:", attemptCount.ToString("N0"), stopwatch.Elapsed.TotalSeconds);
        }

        public static PipePackingResult Execute2(int binSize, int[] pipes)
        {
            var packer = new Packer(binSize);

            List<Bin> currentSmallestPacks = null;
            var solutions = new int[pipes.Count() + 1];

            var stopwatch = Stopwatch.StartNew();

            var attemptCount = 0;

            foreach (var pipePermtation in Permutation.GetPermutations(pipes))
            {
                var packedBins = packer.Pack(pipePermtation, false);

                solutions[packedBins.Count]++;

                if (IsBetterSolution(currentSmallestPacks, packedBins))
                {
                    currentSmallestPacks = packedBins;
                }

                attemptCount++;
            }

            stopwatch.Stop();

            return new PipePackingResult(pipes, currentSmallestPacks.Count(), solutions, currentSmallestPacks, attemptCount, stopwatch.Elapsed);
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

        public static BigInteger GetPermutationsCount(IList<int> ints)
        {
            if (!ints.Any())
            {
                return 0;
            }

            var groups = ints.GroupBy(i => i);

            var numerator = new BigInteger(ints.Count()).Factorial();

            var denominator =  new BigInteger(1);
            foreach (var @group in groups)
            {
                denominator *= new BigInteger(@group.Count()).Factorial();
            }

            return numerator/denominator;
        }
    }
}
