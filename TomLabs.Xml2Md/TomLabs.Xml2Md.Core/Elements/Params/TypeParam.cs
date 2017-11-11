using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Params
{
	public class TypeParam : Param
	{
		public new const string ELEMENT_NAME = "typeparam";

		public TypeParam(XElement xElement) : base(xElement)
		{
		}
	}
}
