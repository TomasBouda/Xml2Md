using System;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Generators.Markdown
{
	public static class MarkdownTableGenerator
	{
		private static Type LastElementType { get; set; }

		/// <summary>
		/// Renders given element as markdown table.
		/// If last rendered element is different <see cref="Type"/> than given <paramref name="elm"/>, then table header will be rendered.
		/// </summary>
		/// <param name="elm"></param>
		/// <param name="header"></param>
		/// <param name="body"></param>
		/// <returns></returns>
		public static string Render(Element elm, string header, string body)
		{
			if (LastElementType != elm.GetType())
			{
				LastElementType = elm.GetType();
				return RenderHeader(header) + Render(elm, header, body);
			}

			return body;
		}

		/// <summary>
		/// Resets <see cref="LastElementType"/> if given element is not equal to <see cref="LastElementType"/> in order to render header next time.
		/// </summary>
		/// <param name="elm"></param>
		public static void ResetIf(Element elm)
		{
			if (LastElementType != elm.GetType())
			{
				LastElementType = null;
			}
		}

		private static string RenderHeader(string header)
		{
			return $"\n\n{header} | Description\n--- | ---\n";
		}
	}
}
