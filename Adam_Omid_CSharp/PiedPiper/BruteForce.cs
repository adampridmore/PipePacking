using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace PiedPiper
{
    public static class BruteForce
    {
        public static PipePackingResult Execute(int binSize, int[] pipes)
        {
            int[] currentSmallestPipes = null;
            int? smallestNumberOfBins = null;

            var totalPermutations = Permutation.GetPermutationsCount(pipes);
            var packer = new Packer(binSize);
            var solutions = new int[pipes.Count() + 1];
            var stopwatch = Stopwatch.StartNew();
            var attemptCount = 0;

            foreach(var pipePermtation in Permutation.GetPermutations(pipes))
            {
                var numberOfBinsRequired = GetNumberOfBinsRequired(packer, pipePermtation);
                
                solutions[numberOfBinsRequired]++;

                if (IsBetterSolution(smallestNumberOfBins, numberOfBinsRequired))
                {
                    currentSmallestPipes = pipePermtation;
                    smallestNumberOfBins = numberOfBinsRequired;
                }

                attemptCount++;
                if (attemptCount % 1000000 == 0)
                {
                    WriteProgressToConsole(attemptCount, stopwatch, totalPermutations, smallestNumberOfBins);
                }
            }

            stopwatch.Stop();

            return new PipePackingResult(
                binSize,pipes, 
                solutions, 
                packer.Pack(currentSmallestPipes), 
                attemptCount, 
                stopwatch.Elapsed);
        }

        private static void WriteProgressToConsole(int attemptCount, Stopwatch stopwatch, BigInteger totalPermutations, int? smallestNumberOfBins)
        {
            var tps = attemptCount/stopwatch.Elapsed.TotalSeconds;

            var secondsToGo = (totalPermutations - attemptCount)/new BigInteger(tps);
            var completeAt = DateTime.Now + TimeSpan.FromSeconds((int) secondsToGo);

            Console.WriteLine("Attempt: {0}, TPS: {1}, CompleteAt:{2}, SecondsToGo: {3}, BestSoFar: {4}",
                attemptCount.ToString("N0"),
                tps.ToString("N0"),
                completeAt,
                secondsToGo,
                smallestNumberOfBins
                );
        }

        private static int GetNumberOfBinsRequired(Packer packer, int[] pipePermtation)
        {
            return packer.QuickPack(pipePermtation);
        }

        private static bool IsBetterSolution(int? smallestNumberOfBins, int numberOfBins)
        {
            if (smallestNumberOfBins == null)
            {
                return true;
            }
            if (smallestNumberOfBins > numberOfBins)
            {
                return true;
            }
            return false;
        }
    }
}
