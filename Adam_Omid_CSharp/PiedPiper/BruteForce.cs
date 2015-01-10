using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

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
                var numberOfBins = GetNumberOfBins(packer, pipePermtation);
                
                solutions[numberOfBins]++;

                if (IsBetterSolution(smallestNumberOfBins, numberOfBins))
                {
                    currentSmallestPipes = pipePermtation;
                    smallestNumberOfBins = numberOfBins;
                }

                attemptCount++;
                if (attemptCount % 1000000 == 0)
                {
                    WriteProgressToConsole(attemptCount, stopwatch, totalPermutations);
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

        private static void WriteProgressToConsole(int attemptCount, Stopwatch stopwatch, BigInteger totalPermutations)
        {
            var tps = attemptCount/stopwatch.Elapsed.TotalSeconds;

            var secondsToGo = (totalPermutations - attemptCount)/new BigInteger(tps);
            var completeAt = DateTime.Now + TimeSpan.FromSeconds((int) secondsToGo);

            Console.WriteLine("Attempt: {0}, TPS: {1}, CompleteAt:{2}, SecondsToGo: {3}",
                attemptCount.ToString("N0"),
                tps.ToString("N0"),
                completeAt,
                secondsToGo);
        }

        private static int GetNumberOfBins(Packer packer, int[] pipePermtation)
        {
            var numberOfBins = packer.QuickPack(pipePermtation);

//            var numberOfBins2 = packer.Pack(pipePermtation).Count();
//            if (numberOfBins != numberOfBins2)
//            {
//                throw new Exception("Error");
//            }

            return numberOfBins;
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
