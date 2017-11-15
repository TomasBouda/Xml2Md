using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Extensions
{
	/// <summary>
	/// XML related extension methods
	/// </summary>
	internal static class XmlExtensions
	{
		/// <summary>
		/// Creates tree of <see cref="Element"/>s by traversing through XML nodes
		/// </summary>
		/// <param name="node"></param>
		/// <returns>Root element</returns>
		public static Element ToDocumentTree(this XNode node)
		{
			var xElement = node as XElement;

			DocumentMapper.ElementTypeMapping.TryGetValue(xElement.Name.LocalName, out var element);    // Returns mapped Type by element name
			var instance = element != null
				? Activator.CreateInstance(element, new[] { xElement }) as Element  // Creates instance from returned mapping. Execution continues in Element constructor.
				: new Element(xElement);    // Unknown element is by default Element

			return instance;
		}

		/// <summary>
		/// Creates tree of <see cref="List{Element}"/> by traversing through XML nodes
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static List<Element> ToDocumentTree(this IEnumerable<XNode> nodes)
		{
			var elements = new List<Element>();
			foreach (var node in nodes)
			{
				elements.Add(node.ToDocumentTree());
			}
			return elements;
		}
	}
}
