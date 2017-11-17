using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Example : Element
	{
		public Example(XElement xElement) : base(xElement)
		{
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
