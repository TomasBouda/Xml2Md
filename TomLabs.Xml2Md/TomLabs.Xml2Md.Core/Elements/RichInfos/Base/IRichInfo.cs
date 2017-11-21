using TomLabs.Xml2Md.Core.Generators;

namespace TomLabs.Xml2Md.Core.Elements.RichInfos
{
	public interface IRichInfo
	{
		string Text { get; set; }

		string ToString(ElementStyles style);
	}
}
