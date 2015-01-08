using System.Collections.Generic;
using System.Linq;

namespace PiedPiper
{
    public class Packer
    {
        private readonly int _binSize;

        public class Bin
        {
            private readonly List<int> _pipes = new List<int>();

            public int CurrentSize()
            {
                return _pipes.Sum(p => p);
            }

            public void Add(int pipe)
            {
                _pipes.Add(pipe);
            }

            public int PipeCount
            {
                get { return _pipes.Count; }
            }

            public int this[int index]
            {
                get { return _pipes[index]; }
            }

            public IEnumerable<int> Pipes
            {
                get { return _pipes; }
            } 
        }

        public Packer(int binSize )
        {
            _binSize = binSize;
        }

        public List<Bin> Pack(List<int> pipes, bool coolSorting = true)
        {
            pipes = pipes.OrderByDescending(p  => p).ToList();

            var bins = new List<Bin>();

            foreach(var pipe in pipes)
            {
                if (!Fit(bins, pipe))
                {
                    var newBin = new Bin();
                    newBin.Add(pipe);
                    bins.Add(newBin);
                }
            }

            return bins;
        }

        private bool Fit(IEnumerable<Bin> bins, int pipe)
        {
            foreach (var bin in bins)
            {
                if (bin.CurrentSize() + pipe <= _binSize)
                {
                    bin.Add(pipe);
                    return true;
                }
            }

            return false;
        }
    }
}
