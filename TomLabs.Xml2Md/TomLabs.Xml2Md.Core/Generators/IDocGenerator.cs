using TomLabs.Xml2Md.Core.Elements;

namespace TomLabs.Xml2Md.Core.Generators
{
	public interface IDocGenerator
	{
		Element DocumentRoot { get; }

		ElementStyles ElementStyles { get; }

		string Render();
	}
}
