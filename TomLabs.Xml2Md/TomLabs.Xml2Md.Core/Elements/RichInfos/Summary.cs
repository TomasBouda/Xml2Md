using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Summary : RichInfo
	{
		public new const string ELEMENT_NAME = "summary";

		public Summary(XElement xElement) : base(xElement)
		{
		}
	}
}
