using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos.Params
{
	public class Param : RichInfo, IRichInfo
	{
		public string ReferenceName { get; set; }

		public virtual Func<XElement, string> NameExtractor => (x) => x.Attribute("name").Value;

		public Param(XElement xElement) : base(xElement)
		{
			ReferenceName = NameExtractor(xElement);
		}
	}
}
