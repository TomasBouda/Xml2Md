using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Extensions;

namespace TomLabs.Xml2Md.Core
{
	public class DocumentMapper
	{
		/// <summary>
		/// Provides mappings for XML element name to Type
		/// eg. seeaslo => <see cref="TomLabs.Xml2Md.Core.Elements.Refs.SeeAlso"/>
		/// </summary>
		public static Dictionary<string, Type> ElementTypeMapping { get; private set; } = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.IsClass && !t.IsAbstract && typeof(Element).IsAssignableFrom(t))
			.ToDictionary(t => t.Name.ToLower(), t => t);

		private XNode XmlDocumentNode { get; set; }

		public DocumentMapper(XNode xmlNode)
		{
			XmlDocumentNode = xmlNode;
		}

		public DocumentMapper(XNode xmlNode, Dictionary<string, Type> customMappings)
		{
			XmlDocumentNode = xmlNode;
			ElementTypeMapping = ElementTypeMapping
				.Union(customMappings)
				.ToDictionary(t => t.Key, t => t.Value);
		}

		public Element Map()
		{
			return XmlDocumentNode.ToDocumentTree();
		}
	}
}
