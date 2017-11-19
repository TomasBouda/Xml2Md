using System;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Generators.Markdown
{
	public static class MarkdownTableGenerator
	{
		private static Type LastElementType { get; set; }

		public static string Render(Element elm, string header, string body)
		{
			if (LastElementType != elm.GetType())
			{
				LastElementType = elm.GetType();
				return RenderHeader(header) + Render(elm, header, body);
			}

			return body;
		}

		private static string RenderHeader(string header)
		{
			return $"\n\n{header} | Description\n--- | ---\n";
		}
	}
}
