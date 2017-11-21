namespace TomLabs.Xml2Md.Core.Generators.Data
{
	public class DocumentLink
	{
		private static int _counter = 1;

		public string Address { get; set; }
		public string TypeFullName { get; set; }

		public DocumentLink(string typeFullName)
		{
			TypeFullName = typeFullName;
			Address = $"l{_counter++}";
		}
	}
}
