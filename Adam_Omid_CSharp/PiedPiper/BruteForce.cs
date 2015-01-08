using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PiedPiper
{
    // http://www.mathwarehouse.com/probability/permutations-repeated-items.php

    // TODO: Check for theoretical minimum, and see if we find that, then stop.
    
    public static class BruteForce
    {
        public static void RunBruteForce(int binSize, int[] pipes, bool printVerbose = false)
        {
            var packer = new Packer(binSize);

            // Pipes need to be ordered ascending for the next permutations generator to get the next solution.
            var pipesToTry = pipes.OrderBy(x => x).ToArray();

            List<Packer.Bin> currentSmallestPacks = null;

            var stopwatch = Stopwatch.StartNew();

            int attemptCount = 0;

            do
            {
                var packedBins = packer.Pack(pipesToTry, false);

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
                    Console.WriteLine("Done: {0}", attemptCount);
                }
            } while (Permutation.NextPermutation(pipesToTry));

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("A Best Solution:");
            PrintPackedBins(currentSmallestPacks, null);

            Console.WriteLine("Solutions tried: {0}, Duration {1}s:",attemptCount, stopwatch.Elapsed.Seconds);
        }

        private static bool IsBetterSolution(List<Packer.Bin> currentSmallestPacks, List<Packer.Bin> packedBins)
        {
            if (currentSmallestPacks == null)
            {
                return true;
            }
            if (currentSmallestPacks.Count > packedBins.Count)
            {
                return true;
            }
            return false;
        }

        private static void PrintPackedBins(List<Packer.Bin> packedBins, int[] pipes)
        {
            Console.WriteLine("Number of bins: " + packedBins.Count);

            if (pipes != null)
            {
                Console.WriteLine("Pipes to pack:  " + String.Join(",", pipes));
            }

            foreach (var packedBin in packedBins)
            {
                Console.WriteLine(String.Join(",", packedBin.Pipes));
            }
        }
    }
}
