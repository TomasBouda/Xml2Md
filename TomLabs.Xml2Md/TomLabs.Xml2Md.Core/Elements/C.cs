using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class C : Element
	{
		public new const string ELEMENT_NAME = "c";

		public C(XElement xElement) : base(xElement)
		{
		}
	}
}
