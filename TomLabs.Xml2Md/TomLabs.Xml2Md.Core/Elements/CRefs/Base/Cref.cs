using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Crefs
{
	public abstract class Cref : Element
	{
		/// <summary>
		/// cref attribute value
		/// </summary>
		public string CRef { get; set; }

		/// <summary>
		/// Type of element reference <see cref="EReferenceType"/>
		/// </summary>
		public EReferenceType ReferenceType { get; }

		/// <summary>
		/// Reference value with stripped of <see cref="ReferenceType"/>
		/// </summary>
		public string ReferenceValue { get; }

		public virtual Func<XElement, string> CRefExtractor => (x) => x.Attribute("cref").Value;

		public Cref(XElement xElement) : base(xElement)
		{
			CRef = CRefExtractor(xElement);

			ReferenceType = ResolveReferenceType(CRef);
			ReferenceValue = StripOfReferenceType(CRef);
		}
	}
}
