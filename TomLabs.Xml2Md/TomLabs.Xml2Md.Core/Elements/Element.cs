using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Extensions;
using TomLabs.Xml2Md.Core.Generators.Data;

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
		Event,
		Namespace
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
				["N:"] = EReferenceType.Namespace
			};

		public string Text { get; set; }

		/// <summary>
		/// Elements child elements
		/// </summary>
		public List<Element> ChildElements { get; set; }

		/// <summary>
		/// Function for extracting text from XML element
		/// </summary>
		public virtual Func<XElement, string> TextExtractor => (x) => x.Value.RemoveTabs();

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

		/// <summary>
		/// Replaces complex XML nodes with {i} symbols which are later filled with rendered childes
		/// </summary>
		/// <param name="nodes"></param>
		/// <returns></returns>
		protected string PrepareRichInfo(IEnumerable<XNode> nodes)
		{
			var output = new StringBuilder();
			int i = 0;
			foreach (var node in nodes)
			{
				if (Regex.IsMatch(node.ToString(), @"<(.*?)/>|<\w+>(\s+)?(.*?)(\s+)?</\w+>"))   // match XML elements
				{
					output.Append("{" + i + "}");
					i++;
				}
				else
				{
					output.Append(node.ToString().RemoveTabs());
				}
			}
			return output.ToString();
		}

		public override string ToString()
		{
			return Text;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="styles"></param>
		/// <returns></returns>
		public virtual string ToString(ElementStyles styles)
		{
			var format = styles.GetStyle(this);
			if (format != null)
			{
				return ToString(format);
			}
			else
			{
				return ToString();
			}
		}

		public virtual string ToString(Func<Element, string> format)
		{
			return format(this);
		}
	}
}
