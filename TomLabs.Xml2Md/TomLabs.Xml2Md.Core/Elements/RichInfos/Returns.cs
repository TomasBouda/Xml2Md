using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Returns : RichInfo
	{
		public new const string ELEMENT_NAME = "returns";

		public Returns(XElement xElement) : base(xElement)
		{
		}
	}
}
