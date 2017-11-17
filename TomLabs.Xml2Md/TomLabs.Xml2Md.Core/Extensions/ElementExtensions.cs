using System;
using System.Collections.Generic;
using System.Text;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Extensions
{
	internal static class ElementExtensions
	{
		public static string Render(this Element element, Dictionary<Type, Func<Element, string>> styles)
		{
			styles.TryGetValue(element.GetType(), out var format);
			return format(element);
		}

		public static string Render(this List<Element> elements, Dictionary<Type, Func<Element, string>> styles)
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
