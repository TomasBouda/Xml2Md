using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TomLabs.Shadowgem.Extensions.String;
using TomLabs.Xml2Md.Core.Elements.RichInfos;

namespace TomLabs.Xml2Md.Core.Elements.Refs.Crefs
{
	public class Exception : Cref, IRichInfo
	{
		public override Func<XElement, string> TextExtractor => (x) => PrepareRichInfo(x.Nodes());

		public Exception(XElement xElement) : base(xElement)
		{

		}

		public override string ToString(Dictionary<Type, Func<Element, string>> style)
		{
			return Text.FillIn(ChildElements.Select(e => e.ToString(style)).ToArray());
		}
	}
}
