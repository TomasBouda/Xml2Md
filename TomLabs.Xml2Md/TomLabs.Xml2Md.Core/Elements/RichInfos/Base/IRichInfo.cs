using System;
using System.Collections.Generic;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public interface IRichInfo
	{
		string Text { get; set; }

		string ToString(Dictionary<Type, Func<Element, string>> style);
	}
}
