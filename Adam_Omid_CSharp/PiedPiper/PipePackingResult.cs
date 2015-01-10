using System;
using System.Collections.Generic;
using System.Text;

namespace PiedPiper
{
    public class PipePackingResult
    {
        public PipePackingResult(int[] pipes, int minimumNumberOfBinsRequired, 
            int[] solutionsCounts, IEnumerable<Bin> aBestSolution,
            int numberOfAttempts, TimeSpan duration)
        {
            Pipes = pipes;
            MinimumNumberOfBinsRequired = minimumNumberOfBinsRequired;
            SolutionsCounts = solutionsCounts;
            ABestSolution = aBestSolution;
            NumberOfPermutationsTried = numberOfAttempts;
            Duration = duration;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Pipes: {0}{1}", String.Join(",",Pipes), Environment.NewLine);
            sb.AppendFormat("MinimumNumberOfBinsRequired: {0}{1}", MinimumNumberOfBinsRequired, Environment.NewLine);
            sb.AppendFormat("NumberOfPermutationsTried: {0}{1}", NumberOfPermutationsTried.ToString("N0"), Environment.NewLine);
            sb.AppendFormat("Duration: {0}ms{1}", Duration.TotalMilliseconds.ToString("N0"), Environment.NewLine);

            sb.AppendFormat("SolutionsCounts: {0}{1}", String.Join(",", GetSolutionsCountsText(SolutionsCounts)), Environment.NewLine);

            WriteABestSolution(sb);

            return sb.ToString();
        }

        private IEnumerable<string> GetSolutionsCountsText(int[] solutionsCounts)
        {
            for (var i = 0; i < solutionsCounts.Length;i++)
            {
                if (solutionsCounts[i] > 0)
                {
                    yield return String.Format("(Bins: {0}, SolutionsCount: {1})", i, solutionsCounts[i]);
                }
            }
        }

        private void WriteABestSolution(StringBuilder sb)
        {
            sb.AppendLine("ABestSolution:");
            foreach (var bin in ABestSolution)
            {
                var binText = String.Join(",", bin.Pipes);
                sb.AppendFormat("{0} ({1}){2}", binText, bin.CurrentSize(), Environment.NewLine);
            }
        }

        public int[] Pipes { get; private set; }
        public int MinimumNumberOfBinsRequired { get; private set; }
        public int[] SolutionsCounts { get; private set; }
        public IEnumerable<Bin> ABestSolution { get; private set; }
        public int NumberOfPermutationsTried { get; private set; }
        public TimeSpan Duration { get; private set; }
    }
}