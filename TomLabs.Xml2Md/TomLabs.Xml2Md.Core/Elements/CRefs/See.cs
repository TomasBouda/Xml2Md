using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Crefs
{
	public class See : Cref
	{
		public new const string ELEMENT_NAME = "see";

		public See(XElement xElement) : base(xElement)
		{

		}
	}
}
