using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class TypeParamRef : Param
	{
		public new const string ELEMENT_NAME = "typeparamref";

		public override Func<XElement, string> TextExtractor => (x) => x.Value;

		public TypeParamRef(XElement xElement) : base(xElement)
		{
		}
	}
}
