using System.Collections.Generic;
using System.Linq;
using TomLabs.Shadowgem.Extensions.String;

namespace TomLabs.Xml2Md.Core.Extensions
{
	public static class StringExtensions
	{
		public static List<string> SplitNamespace(this string s)
		{
			return s.ReplaceRgx(@"\(.*\)", "").SplitRgx(@"\.?(.\w+)").Where(x => x != string.Empty).ToList();
		}

		public static string RemoveRedundantLineBreaks(this string s)
		{
			return s.Trim().ReplaceRgx(@"\n\n\n+", "\n\n");
		}

		public static string RRLB(this string s)
		{
			return s.RemoveRedundantLineBreaks();
		}

		public static string RemoveTabs(this string s)
		{
			return s.ReplaceRgx(@"[^\S\r\n\t]{2,}", "");
		}
	}
}
