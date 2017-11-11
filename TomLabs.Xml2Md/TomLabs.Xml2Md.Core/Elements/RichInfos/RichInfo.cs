using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public abstract class RichInfo : Element
	{
		public override Func<XElement, string> TextExtractor => (x) => String.Concat(x.Nodes());

		public RichInfo(XElement xElement) : base(xElement)
		{

		}
	}
}
