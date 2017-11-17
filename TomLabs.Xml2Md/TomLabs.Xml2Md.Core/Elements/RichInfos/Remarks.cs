using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Remarks : RichInfo, IRichInfo
	{
		public Remarks(XElement xElement) : base(xElement)
		{
		}
	}
}
