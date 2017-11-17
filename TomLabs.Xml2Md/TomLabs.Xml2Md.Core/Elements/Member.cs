using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Member : Element
	{
		public EReferenceType ReferenceType { get; }

		public string ReferenceName { get; set; }

		public virtual Func<XElement, string> NameExtractor => (x) => x.Attribute("name").Value;

		public Member(XElement xElement) : base(xElement)
		{
			ReferenceName = NameExtractor(xElement);

			ReferenceType = ResolveReferenceType(ReferenceName);
			ReferenceName = StripOfReferenceType(ReferenceName);
		}

		public override string ToString()
		{
			return ReferenceName;
		}
	}
}
