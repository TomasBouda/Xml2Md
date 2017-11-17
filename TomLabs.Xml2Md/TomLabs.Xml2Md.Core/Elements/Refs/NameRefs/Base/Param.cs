using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Refs.NameRefs
{
	public class NameRef : Element
	{
		public string ReferenceName { get; set; }

		public virtual Func<XElement, string> NameExtractor => (x) => x.Attribute("name").Value;

		public NameRef(XElement xElement) : base(xElement)
		{
			ReferenceName = NameExtractor(xElement);
		}
	}
}
