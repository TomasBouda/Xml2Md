using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class C : Element
	{
		public C(XElement xElement) : base(xElement)
		{
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
