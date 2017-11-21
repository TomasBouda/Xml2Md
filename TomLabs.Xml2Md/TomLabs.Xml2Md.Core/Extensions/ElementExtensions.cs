using System.Collections.Generic;
using System.Text;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Generators.Data;

namespace TomLabs.Xml2Md.Core.Extensions
{
	internal static class ElementExtensions
	{
		public static string Render(this Element element, ElementStyles styles)
		{
			var format = styles.GetStyle(element);
			return format?.Invoke(element);
		}

		public static string Render(this List<Element> elements, ElementStyles styles)
		{
			var sb = new StringBuilder();
			foreach (var elem in elements)
			{
				sb.Append(elem.Render(styles));
			}
			return sb.ToString();
		}
	}
}
