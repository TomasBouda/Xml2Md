using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Summary : RichInfo, IRichInfo
	{
		public Summary(XElement xElement) : base(xElement)
		{
		}
	}
}
