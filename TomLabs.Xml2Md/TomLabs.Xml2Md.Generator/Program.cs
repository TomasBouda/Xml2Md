using System.IO;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core;

namespace TomLabs.Xml2Md.Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			var inReader = new StreamReader(args[0]);
			var xml = inReader.ReadToEnd();
			var doc = XDocument.Parse(xml);
			var map = doc.Root.ToDocumentMap();
		}
	}
}
