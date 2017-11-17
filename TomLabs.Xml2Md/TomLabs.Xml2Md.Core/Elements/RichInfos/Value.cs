using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public class Value : RichInfo, IRichInfo
	{
		public Value(XElement xElement) : base(xElement)
		{
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
