using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Code : Element
	{
		public Code(XElement xElement) : base(xElement)
		{
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
