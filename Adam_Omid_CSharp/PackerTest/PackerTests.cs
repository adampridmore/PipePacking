using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class PackerTests
    {
        [TestMethod]
        public void SmokeTest()
        {
            var bins = new Packer(10).Pack(new List<int> {10});

            Assert.AreEqual(1,bins.Count);
            Assert.AreEqual(1,bins[0].PipeCount);
            Assert.AreEqual(10, bins[0][0]);
        }

        [TestMethod]
        public void TwoPipesReturnOneBin()
        {
            var bins = new Packer(10).Pack(new List<int> { 5, 5 });

            Assert.AreEqual(1, bins.Count);
            Assert.AreEqual(2, bins[0].PipeCount);
            Assert.AreEqual(5, bins[0][0]);
            Assert.AreEqual(5, bins[0][1]);
        }

        [TestMethod]
        public void TwoPipesReturnTwoBin()
        {
            var bins = new Packer(5).Pack(new List<int> { 5, 5 });

            Assert.AreEqual(2, bins.Count);
            
            Assert.AreEqual(1, bins[0].PipeCount);
            Assert.AreEqual(5, bins[0][0]);

            Assert.AreEqual(1, bins[1].PipeCount);
            Assert.AreEqual(5, bins[1][0]);
        }

        [TestMethod]
        public void ThePizzaTest()
        {
            RunExample(13, new List<int> { 1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9 });
        }

        private void RunExample(int binSize, List<int> pipes)
        {
            Console.WriteLine("BinSize: " + binSize);
            
            Console.WriteLine(String.Join(",", pipes));
            Console.WriteLine("Total Pipes Size: " + pipes.Sum(p => p));
            Console.WriteLine("Min Bins : " + Math.Ceiling(pipes.Sum(p => p) / 13M));
            
            var bins = new Packer(binSize).Pack(pipes);

            Console.WriteLine("Solution: Bins Count: " + bins.Count);
            foreach (var bin in bins)
            {
                Console.WriteLine(String.Join(",", bin.Pipes));
            }
        }

        [TestMethod]
        public void FitFirstChallenge()
        {
            RunExample(10, new List<int> { 2, 2, 3, 4, 4, 5 });
        }

        [TestMethod]
        public void SubOptimal()
        {
            RunExample(11, new List<int> { 7, 2, 2,2, 3, 3, 3 });
        }

        [TestMethod]
        public void BruteForce1()
        {
            var pipes = new[] {7, 3, 3, 3, 2, 2, 2};
            BruteForce.Execute(11, pipes);
        }

        [TestMethod]
        [Ignore]
        public void BruteForce2()
        {
            var pipes = new[] {1, 1, 3, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9};

            BruteForce.Execute(13, pipes);
        }

        [TestMethod]
        public void QuickPacker()
        {
            var numberOfBinsRequired = new Packer(10).QuickPack(new[] {1, 2, 3});

            Assert.AreEqual(1, numberOfBinsRequired);
        }

        [TestMethod]
        public void QuickPacker_for_no_pipes()
        {
            var numberOfBinsRequired = new Packer(10).QuickPack(new int [] {});

            Assert.AreEqual(0, numberOfBinsRequired);
        }

        [TestMethod]
        public void QuickPacker_for_a_few_pipes()
        {
            var pipes = new[] { 5,4,4,3 };

            var numberOfBins = new Packer(8).QuickPack(pipes);
            Assert.AreEqual(3, numberOfBins);
        }

        [TestMethod]
        public void QuickPacker_for_a_problem_set_of_pipes()
        {
            var pipes = new[] { 7, 2, 2, 3, 3, 3, 2 };

            var numberOfBins = new Packer(11).QuickPack(pipes);
            Assert.AreEqual(2, numberOfBins);
        }
    }
}
