using System;
using System.Collections.Generic;
using System.Text;

namespace PiedPiper
{
    public static class BinListUtils
    {
        public static string ToResultString(this IEnumerable<Bin> bins)
        {
            var sb = new StringBuilder();
            sb.AppendLine("A Best Solution:");
            foreach (var bin in bins)
            {
                var binText = string.Join(",", bin.Pipes);
                sb.AppendFormat("{0} ({1}){2}", binText, bin.CurrentSize(), Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
