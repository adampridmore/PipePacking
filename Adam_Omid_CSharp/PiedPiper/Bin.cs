using System;
using System.Collections.Generic;
using System.Linq;

namespace PiedPiper
{
    public class Bin
    {
        private readonly int _binSize;

        public Bin(int binSize)
        {
            _binSize = binSize;
        }

        public override string ToString()
        {
            var pipesText = String.Join(",", Pipes);
            var space = _binSize - Pipes.Sum();

            return String.Format("{0} - ({1})", pipesText, space);
        }

        private readonly List<int> _pipes = new List<int>();
        private int _currentSize;

        public int CurrentSize()
        {
            return _currentSize;
        }

        public void Add(int pipe)
        {
            _pipes.Add(pipe);
            _currentSize += pipe;
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

        public bool TryAddPipe(int pipe)
        {
            if (DoesPipeFit(pipe))
            {
                Add(pipe);
                return true;
            }
            return false;
        }

        private bool DoesPipeFit(int pipe)
        {
            return CurrentSize() + pipe <= _binSize;
        }
    }
}