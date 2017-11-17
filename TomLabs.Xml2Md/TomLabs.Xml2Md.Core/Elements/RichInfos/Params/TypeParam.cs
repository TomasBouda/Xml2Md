using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos.Params
{
	public class TypeParam : Param, IRichInfo
	{
		public TypeParam(XElement xElement) : base(xElement)
		{
		}
	}
}
