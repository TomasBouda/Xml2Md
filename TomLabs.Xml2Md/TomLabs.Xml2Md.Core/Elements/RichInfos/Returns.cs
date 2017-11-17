using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Returns : RichInfo, IRichInfo
	{
		public Returns(XElement xElement) : base(xElement)
		{
		}
	}
}
