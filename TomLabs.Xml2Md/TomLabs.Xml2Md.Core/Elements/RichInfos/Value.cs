using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Value : RichInfo
	{
		public new const string ELEMENT_NAME = "value";

		public Value(XElement xElement) : base(xElement)
		{
		}
	}
}
