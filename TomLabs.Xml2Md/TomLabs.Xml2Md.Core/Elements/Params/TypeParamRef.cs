using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class TypeParamRef : Param
	{
		public override Func<XElement, string> TextExtractor => (x) => x.Value;

		public TypeParamRef(XElement xElement) : base(xElement)
		{
		}
	}
}
