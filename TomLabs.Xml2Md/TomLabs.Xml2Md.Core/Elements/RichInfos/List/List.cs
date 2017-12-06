using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos.Lists
{
	public enum EListType
	{
		Bullet,
		Number,
		Table
	}

	public class List : RichInfo, IRichInfo
	{
		public EListType Type { get; set; }

		public virtual Func<XElement, string> TypeExtractor => (x) => x.Attribute("type").Value;

		public List(XElement xElement) : base(xElement)
		{
			Type = ToListType(TypeExtractor(xElement));
		}

		private EListType ToListType(string type)
		{
			switch (type)
			{
				case "bullet": return EListType.Bullet;
				case "number": return EListType.Number;
				case "table": return EListType.Table;
				default: return EListType.Bullet;
			}
		}
	}
}
