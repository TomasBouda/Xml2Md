using System.Text;

namespace TomLabs.Xml2Md.Tests.DummyClasses
{
	/// <summary>
	/// This is the first class
	/// <seealso cref="Blabla.Class2"/>
	/// </summary>
	public class Class1
	{
		/// <summary>
		/// Constantan is alloy
		/// 
		/// </summary>
		public const string SOME_CONST = "HI";

		/// <summary>
		/// Large corn field... wait it's just <see cref="char"/>
		/// </summary>
		public char Field;

		/// <summary>
		/// This is my property
		/// </summary>
		public decimal Property { get; set; }

		/// <summary>
		/// Some comments about this awesome method
		/// </summary>
		/// <exception cref="System.Exception">Thrown who know when... actually is thrown when <typeparamref name="T"/> doesn't like <typeparamref name="U"/></exception>
		/// <permission cref="System.Security.PermissionSet">Everyone can access this method.</permission>
		/// <remarks>
		/// Well, some additional text about this method that is <see cref="Blabla.Class2.IsGreat"/>
		/// </remarks>
		/// <example>
		/// var sb = new StringBuilder();
		///	for(int i = 0; i &lt; 100; i++)
		///	{
		///		sb.AppendLine($"Line number {i}");
		///	}
		///	string output = sb.ToString();
		/// </example>
		/// <typeparam name="T">First type param</typeparam>
		/// <typeparam name="U">Output type param</typeparam>
		/// <param name="input">Put it here</param>
		/// <param name="number">Some numba yo</param>
		/// <param name="bit"><c>true</c> or <c>false</c> that make sense</param>
		/// <param name="price">Yep price has decimal places</param>
		/// <param name="sb">Bob Builder friend</param>
		/// <param name="someStruct">Struct of type <typeparamref name="T"/></param>
		/// <returns>Returns something of type <typeparamref name="U"/></returns>
		public U SomePublicMethod<T, U>(string input, int number, bool bit, float price, StringBuilder sb, T someStruct) where T : struct
		{
			return default(U);
		}
	}
}
