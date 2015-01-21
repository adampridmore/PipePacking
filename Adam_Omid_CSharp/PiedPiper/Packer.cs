using System.Collections.Generic;
using System.Linq;

namespace PiedPiper
{
    public class Packer
    {
        private readonly int _packetSize;

        public Packer(int packetSize)
        {
            _packetSize = packetSize;
        }

        public List<Bin> Pack(IEnumerable<int> pipes)
        {
            if (pipes == null || !pipes.Any())
            {
                return new List<Bin>();
            }

            var bins = new List<Bin>();
            var currentBin = new Bin(_packetSize);
            bins.Add(currentBin);

            foreach (var pipe in pipes)
            {
                if (!currentBin.TryAddPipe(pipe))
                {
                    currentBin = new Bin(_packetSize);
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

            var currentPacketRemainning = 0;
            var numberOfPacketsUsed = 0;

            foreach (var pipe in pipes)
            {
                if (currentPacketRemainning - pipe < 0)
                {
                    currentPacketRemainning = _packetSize;
                    numberOfPacketsUsed++;
                }
                currentPacketRemainning -= pipe;
            }

            return numberOfPacketsUsed;
        }
    }
}
