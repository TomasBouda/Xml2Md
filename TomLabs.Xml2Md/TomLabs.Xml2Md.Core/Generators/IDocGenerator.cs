using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Generators.Data;

namespace TomLabs.Xml2Md.Core.Generators
{
	public interface IDocGenerator
	{
		Element DocumentRoot { get; }

		ElementStyles ElementStyles { get; }

		string Render();
	}
}
