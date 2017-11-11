using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Crefs
{
	public abstract class Cref : Element
	{
		public string CRef { get; set; }

		public EReferenceType ReferenceType { get; }

		public string ReferenceValue { get; }

		public virtual Func<XElement, string> CRefExtractor => (x) => x.Attribute("cref").Value;

		public Cref(XElement xElement) : base(xElement)
		{
			CRef = CRefExtractor(xElement);

			ReferenceType = ReferenceTypePrefixes[ReferencePrefixRegex.Match(CRef)?.Value];
			ReferenceValue = ReferencePrefixRegex.Replace(CRef, "");
		}
	}
}
