using System;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core.Elements.RichInfos;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class Param : RichInfo
	{
		public new const string ELEMENT_NAME = "param";

		public string Name { get; set; }

		public virtual Func<XElement, string> NameExtractor => (x) => x.Attribute("name").Value;

		public Param(XElement xElement) : base(xElement)
		{
			Name = NameExtractor(xElement);
		}
	}
}
