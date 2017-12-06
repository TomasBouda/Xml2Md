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
		/// e.g. seealso => <see cref="TomLabs.Xml2Md.Core.Elements.Refs.SeeAlso"/>
		/// </summary>
		public static Dictionary<string, Type> ElementTypeMapping { get; private set; } = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.IsClass && !t.IsAbstract && typeof(Element).IsAssignableFrom(t))  // gets all types that inherit from Element and are not abstract
			.ToDictionary(t => t.Name.ToLower(), t => t);

		private XNode XmlDocumentNode { get; set; }

		public DocumentMapper(XNode xmlNode)
		{
			XmlDocumentNode = xmlNode;
		}

		/// <summary>
		/// Creates instance of new DocumentMapper and adds given <paramref name="customMappings"/> into <see cref="ElementTypeMapping"/>
		/// </summary>
		/// <param name="xmlNode"></param>
		/// <param name="customMappings">Custom XML element mapping. E.g. {"see", typeof(See)}</param>
		public DocumentMapper(XNode xmlNode, Dictionary<string, Type> customMappings)
		{
			XmlDocumentNode = xmlNode;
			ElementTypeMapping = ElementTypeMapping
				.Union(customMappings)
				.ToDictionary(t => t.Key, t => t.Value);
		}

		/// <summary>
		/// Creates <see cref="Element"/> tree
		/// </summary>
		/// <returns></returns>
		public Element Map()
		{
			return XmlDocumentNode.ToDocumentTree();
		}
	}
}
