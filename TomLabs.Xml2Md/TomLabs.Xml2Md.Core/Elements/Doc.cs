using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements
{
	public class Doc : Element
	{
		public new const string ELEMENT_NAME = "doc";

		public string AssemblyName { get; }

		public override Func<XElement, List<Element>> ChildsExtractor => (x) => x.Element("members").Elements("member").ToDocumentMap();

		public virtual Func<XElement, string> AssemblyNameExtractor => (x) => x.Element("assembly").Element("name").Value;

		public Doc(XElement xElement) : base(xElement)
		{
			AssemblyName = AssemblyNameExtractor(xElement);
		}
	}
}
