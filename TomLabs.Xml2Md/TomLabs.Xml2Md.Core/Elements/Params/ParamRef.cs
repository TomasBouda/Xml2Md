using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class ParamRef : Param
	{
		public override Func<XElement, string> TextExtractor => (x) => x.Value;

		public ParamRef(XElement xElement) : base(xElement)
		{
		}
	}
}
