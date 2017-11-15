using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Extensions;

namespace TomLabs.Xml2Md.Core.Elements
{
	/// <summary>
	/// Reference type mapped from XML element value. T:, M:, P:, F:, E:
	/// Like name="T:TomLabs... or cref="M:Sy
	/// </summary>
	public enum EReferenceType
	{
		Type,
		Method,
		Property,
		Field,
		Event
	}

	public class Element
	{
		protected readonly Regex ReferencePrefixRegex = new Regex(@"(^[A-Z]\:)");

		protected readonly Dictionary<string, EReferenceType> ReferenceTypePrefixes =
			new Dictionary<string, EReferenceType>(StringComparer.OrdinalIgnoreCase)
			{
				["T:"] = EReferenceType.Type,
				["M:"] = EReferenceType.Method,
				["P:"] = EReferenceType.Property,
				["F:"] = EReferenceType.Field,
				["E:"] = EReferenceType.Event,
			};

		public string Text { get; set; }

		/// <summary>
		/// Elements child elements
		/// </summary>
		public List<Element> ChildElements { get; set; }

		/// <summary>
		/// Function for extracting text from XML element
		/// </summary>
		public virtual Func<XElement, string> TextExtractor => (x) => x.Value;

		/// <summary>
		/// Function for extracting <see cref="ChildElements"/> from XML element
		/// </summary>
		public virtual Func<XElement, List<Element>> ChildsExtractor => (x) => x.Elements().ToDocumentTree();

		/// <summary>
		/// Constructs Element
		/// </summary>
		/// <param name="xElement">XML element to construct from</param>
		public Element(XElement xElement)
		{
			Text = TextExtractor(xElement);
			ChildElements = ChildsExtractor(xElement);
		}

		/// <summary>
		/// Resolves <see cref="EReferenceType"/> from string representation(eg. T:)
		/// </summary>
		/// <param name="refName">string type ref, for example F:TomLabs...</param>
		/// <returns></returns>
		protected EReferenceType ResolveReferenceType(string refName)
		{
			return ReferenceTypePrefixes[ReferencePrefixRegex.Match(refName)?.Value];
		}

		/// <summary>
		/// Removes type reference from string. For example F:TomLabs... becomes TomLabs...
		/// </summary>
		/// <param name="refName"></param>
		/// <returns></returns>
		protected string StripOfReferenceType(string refName)
		{
			return ReferencePrefixRegex.Replace(refName, "");
		}
	}
}
