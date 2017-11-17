using System;
using System.Collections.Generic;
using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Generators
{
	public interface IDocGenerator
	{
		Element DocumentRoot { get; }

		Dictionary<Type, Func<Element, string>> ElementStyles { get; }

		string Render();
	}
}
