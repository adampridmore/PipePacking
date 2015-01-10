using System.Collections.Generic;
using System.Linq;

namespace PiedPiper
{
    public class Packer
    {
        private readonly int _binSize;

        public Packer(int binSize )
        {
            _binSize = binSize;
        }

        public List<Bin> Pack(IEnumerable<int> pipes)
        {
            if (pipes == null || !pipes.Any())
            {
                return new List<Bin>();
            }

            var bins = new List<Bin>();
            var currentBin = new Bin(_binSize);
            bins.Add(currentBin);

            foreach (var pipe in pipes)
            {
                if (!currentBin.TryAddPipe(pipe))
                {
                    currentBin = new Bin(_binSize);
                    currentBin.Add(pipe);
                    bins.Add(currentBin);
                }
            }

            return bins;
        }

        public int QuickPack(int[] pipes)
        {
            if (!pipes.Any())
            {
                return 0;
            }

            var currentBinRemainning = 0;
            var numberOfBinsUsed = 0;

            foreach (var pipe in pipes)
            {
                if (currentBinRemainning - pipe < 0)
                {
                    currentBinRemainning = _binSize;
                    numberOfBinsUsed++;
                }

                currentBinRemainning -= pipe;
            }

            return numberOfBinsUsed;
        }
    }
}
