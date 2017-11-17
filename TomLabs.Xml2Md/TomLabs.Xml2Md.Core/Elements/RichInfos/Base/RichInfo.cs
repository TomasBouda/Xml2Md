﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TomLabs.Shadowgem.Extensions.String;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	/// <summary>
	/// Base class for elements that can contain another child elements
	/// </summary>
	public abstract class RichInfo : Element
	{
		public override Func<XElement, string> TextExtractor => (x) => PrepareRichInfo(x.Nodes());

		public RichInfo(XElement xElement) : base(xElement)
		{

		}

		public override string ToString(Dictionary<Type, Func<Element, string>> style)
		{
			return Text.FillIn(ChildElements.Select(e => e.ToString(style)).ToArray());
		}
	}
}
