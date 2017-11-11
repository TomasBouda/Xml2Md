using System.Collections.Generic;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Elements.Crefs;
using TomLabs.Xml2Md.Core.Elements.Params;
using TomLabs.Xml2Md.Core.Elements.RichInfos;

namespace TomLabs.Xml2Md.Core
{
	public static class XmlExtensions
	{
		public static Element ToDocumentMap(this XNode node)
		{
			var xElement = node as XElement;
			switch (xElement.Name.LocalName)
			{
				case Doc.ELEMENT_NAME:
					return new Doc(xElement);
				case Member.ELEMENT_NAME:
					return new Member(xElement);
				case Example.ELEMENT_NAME:
					return new Example(xElement);
				case C.ELEMENT_NAME:
					return new C(xElement);
				case See.ELEMENT_NAME:
					return new See(xElement);
				case SeeAlso.ELEMENT_NAME:
					return new SeeAlso(xElement);
				case EException.ELEMENT_NAME:
					return new EException(xElement);
				case Permission.ELEMENT_NAME:
					return new Permission(xElement);
				case Param.ELEMENT_NAME:
					return new Param(xElement);
				case ParamRef.ELEMENT_NAME:
					return new ParamRef(xElement);
				case TypeParam.ELEMENT_NAME:
					return new TypeParam(xElement);
				case TypeParamRef.ELEMENT_NAME:
					return new TypeParamRef(xElement);
				case Para.ELEMENT_NAME:
					return new Para(xElement);
				case Remarks.ELEMENT_NAME:
					return new Remarks(xElement);
				case Returns.ELEMENT_NAME:
					return new Returns(xElement);
				case Summary.ELEMENT_NAME:
					return new Summary(xElement);
				case Value.ELEMENT_NAME:
					return new Value(xElement);

				default: return new Element(xElement);
			}
		}

		public static List<Element> ToDocumentMap(this IEnumerable<XNode> nodes)
		{
			var elements = new List<Element>();
			foreach (var node in nodes)
			{
				elements.Add(node.ToDocumentMap());
			}
			return elements;
		}
	}
}
