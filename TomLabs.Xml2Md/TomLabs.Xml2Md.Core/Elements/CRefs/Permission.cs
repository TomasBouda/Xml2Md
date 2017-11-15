﻿using System;
using System.Xml.Linq;

namespace TomLabs.Xml2Md.Core.Elements.Crefs
{
	public class Permission : Cref
	{
		public override Func<XElement, string> TextExtractor => (x) => String.Concat(x.Nodes());

		public Permission(XElement xElement) : base(xElement)
		{

		}
	}
}
