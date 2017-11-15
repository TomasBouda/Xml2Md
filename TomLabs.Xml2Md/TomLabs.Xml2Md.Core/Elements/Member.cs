using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Member : Element
	{
		public EReferenceType ReferenceType { get; }

		public string Name { get; set; }

		public virtual Func<XElement, string> NameExtractor => (x) => x.Attribute("name").Value;

		public Member(XElement xElement) : base(xElement)
		{
			Name = NameExtractor(xElement);

			ReferenceType = ResolveReferenceType(Name);
			Name = StripOfReferenceType(Name);
		}
	}
}
