using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Remarks : RichInfo
	{
		public new const string ELEMENT_NAME = "remarks";

		public Remarks(XElement xElement) : base(xElement)
		{
		}
	}
}
