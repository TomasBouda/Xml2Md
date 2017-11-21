using System;
using System.Collections.Generic;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Generators
{
	public class ElementStyles
	{
		private Dictionary<Type, Func<Element, string>> StylesDefinition { get; set; }

		/// <summary>
		/// Action to be executed whenever <see cref="GetStyle(Element)"/> is called
		/// </summary>
		private Action<Element> ExtraAction { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stylesDefinition">Styles mapping</param>
		/// <param name="extraAction">Action to be executed whenever <see cref="GetStyle(Element)"/> is called</param>
		public ElementStyles(Dictionary<Type, Func<Element, string>> stylesDefinition, Action<Element> extraAction = null)
		{
			StylesDefinition = stylesDefinition;
			ExtraAction = extraAction;
		}

		/// <summary>
		/// Returns style assigned for given element type
		/// </summary>
		/// <param name="element"></param>
		/// <returns>Style function that returns formated text</returns>
		public Func<Element, string> GetStyle(Element element)
		{
			Func<Element, string> format = null;
			if (StylesDefinition?.TryGetValue(element.GetType(), out format) ?? false)
			{
				ExtraAction?.Invoke(element);

				return format;
			}
			else
			{
				return null;
			}
		}
	}
}
