using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class ParamRef : Param
	{
		public new const string ELEMENT_NAME = "paramref";

		public override Func<XElement, string> TextExtractor => (x) => x.Value;

		public ParamRef(XElement xElement) : base(xElement)
		{
		}
	}
}
