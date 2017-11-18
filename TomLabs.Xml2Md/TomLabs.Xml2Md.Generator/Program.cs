using System;
using System.IO;
using System.Xml.Linq;
using TomLabs.Xml2Md.Core;
using TomLabs.Xml2Md.Core.Generators.Markdown;

namespace TomLabs.Xml2Md.Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			var inReader = new StreamReader(args[0]);
			var xml = inReader.ReadToEnd();
			var doc = XDocument.Parse(xml);

			var mapper = new DocumentMapper(doc.Root);
			var res = mapper.Map();
			var gen = new MarkdownGenerator(res);
			Console.WriteLine(gen.Render());
			Console.ReadKey();
		}
	}
}
