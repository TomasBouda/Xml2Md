using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Para : RichInfo, IRichInfo
	{
		public Para(XElement xElement) : base(xElement)
		{
		}
	}
}
