using System;
using System.Collections.Generic;
using System.Text;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Extensions
{
	internal static class ElementExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		/// <param name="styles"></param>
		/// <param name="action">If not null then executes provided action on <paramref name="element"/></param>
		/// <returns></returns>
		public static string Render(this Element element, Dictionary<Type, Func<Element, string>> styles, Action<Element> action = null)
		{
			action?.Invoke(element);
			styles.TryGetValue(element.GetType(), out var format);
			return format(element);
		}

		public static string Render(this List<Element> elements, Dictionary<Type, Func<Element, string>> styles, Action<Element> action = null)
		{
			var sb = new StringBuilder();
			foreach (var elem in elements)
			{
				sb.Append(elem.Render(styles, action));
			}
			return sb.ToString();
		}
	}
}
