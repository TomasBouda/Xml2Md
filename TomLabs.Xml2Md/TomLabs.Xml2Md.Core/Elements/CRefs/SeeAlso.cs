using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Crefs
{
	public class SeeAlso : See
	{
		public new const string ELEMENT_NAME = "seealso";

		public SeeAlso(XElement xElement) : base(xElement)
		{

		}
	}
}
