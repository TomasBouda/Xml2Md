using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Example : Element
	{
		public new const string ELEMENT_NAME = "example";

		public Example(XElement xElement) : base(xElement)
		{
		}
	}
}
