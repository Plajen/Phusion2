using System;
using System.Linq;

namespace Phusion2.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToCleanCPF(this string source)
        {
            return string.Concat(source.Where(i => !new[] { '.', '-' }.Contains(i))).Trim();
        }

        public static string ToDirtyCPF(this string source)
        {
            return Convert.ToUInt64(source).ToString(@"000\.000\.000\-00");
        }
    }
}
