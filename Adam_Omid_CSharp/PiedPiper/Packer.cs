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

        public List<Bin> Pack(IEnumerable<int> pipes, bool sort = true)
        {
            if (sort)
            {
                pipes = pipes.OrderByDescending(p => p).ToList();    
            }

            return PackPipes(pipes);
        }

        private List<Bin> PackPipes(IEnumerable<int> pipes)
        {
            var bins = new List<Bin>();

            foreach (var pipe in pipes)
            {
                if (!Fit(bins, pipe))
                {
                    var newBin = new Bin(_binSize);
                    newBin.Add(pipe);
                    bins.Add(newBin);
                }
            }

            return bins;
        }

        private bool Fit(IEnumerable<Bin> bins, int pipe)
        {
            return bins.Any(bin => bin.TryAddPipe(pipe));
        }
    }
}
