using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos.Lists
{
	public class ListHeader : RichInfo, IRichInfo
	{
		public ListHeader(XElement xElement) : base(xElement)
		{

		}
	}
}
