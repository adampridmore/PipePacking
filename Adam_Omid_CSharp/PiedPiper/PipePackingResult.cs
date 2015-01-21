using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiedPiper
{
    public class PipePackingResult
    {
        public PipePackingResult(int binSize, int[] pipes, 
            int[] solutionsCounts, IEnumerable<Bin> aBestSolution,
            int numberOfAttempts, TimeSpan duration)
        {
            BinSize = binSize;
            Pipes = pipes;
            SolutionsCounts = solutionsCounts;
            ABestSolution = aBestSolution;
            NumberOfPermutationsTried = numberOfAttempts;
            Duration = duration;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Pipes: {0}{1}", String.Join(",",Pipes), Environment.NewLine);
            sb.AppendFormat("BinSize: {0}{1}", BinSize, Environment.NewLine);
            sb.AppendFormat("MinimumNumberOfBinsRequired: {0}{1}", MinimumNumberOfBinsRequired, Environment.NewLine);
            sb.AppendFormat("NumberOfPermutationsTried: {0}{1}", NumberOfPermutationsTried.ToString("N0"), Environment.NewLine);
            sb.AppendFormat("Duration: {0}ms{1}", Duration.TotalMilliseconds.ToString("N0"), Environment.NewLine);

            sb.AppendFormat("SolutionsCounts: {0}{1}", String.Join(",", GetSolutionsCountsText(SolutionsCounts)), Environment.NewLine);

            if (ABestSolution != null)
            {
                sb.AppendLine(ABestSolution.ToResultString());    
            }

            return sb.ToString();
        }

        private IEnumerable<string> GetSolutionsCountsText(int[] solutionsCounts)
        {
            for (var i = 0; i < solutionsCounts.Length;i++)
            {
                if (solutionsCounts[i] > 0)
                {
                    yield return String.Format("(Bins: {0}, Count: {1})", i, solutionsCounts[i].ToString("N0"));
                }
            }
        }

        public int BinSize { get; private set; }
        public int[] Pipes { get; private set; }

        public int MinimumNumberOfBinsRequired
        {
            get
            {
                if (ABestSolution == null)
                {
                    return 0;
                }

                return ABestSolution.Count();
            }
        }

        public int[] SolutionsCounts { get; private set; }
        public IEnumerable<Bin> ABestSolution { get; private set; }
        public int NumberOfPermutationsTried { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}