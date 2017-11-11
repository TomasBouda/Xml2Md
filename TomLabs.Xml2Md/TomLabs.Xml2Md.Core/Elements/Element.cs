using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
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
		public readonly string ELEMENT_NAME;

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

		public List<Element> ChildElements { get; set; }

		public virtual Func<XElement, string> TextExtractor => (x) => x.Value;

		public virtual Func<XElement, List<Element>> ChildsExtractor => (x) => x.Elements().ToDocumentMap();

		public Element(XElement xElement)
		{
			Text = TextExtractor(xElement);
			ChildElements = ChildsExtractor(xElement);
		}
	}
}
