using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Para : RichInfo
	{
		public new const string ELEMENT_NAME = "para";

		public Para(XElement xElement) : base(xElement)
		{
		}
	}
}
