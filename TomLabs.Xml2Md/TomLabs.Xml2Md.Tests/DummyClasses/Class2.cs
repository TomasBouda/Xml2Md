using System;

namespace TomLabs.Xml2Md.Tests.DummyClasses.Blabla
{
	/// <summary>
	/// Not flags... flags
	/// </summary>
	[Flags]
	public enum ESomeFlags
	{
		/// <summary>
		/// Nothing in here
		/// </summary>
		none,
		/// <summary>
		/// This is obviously first tag
		/// </summary>
		first,
		/// <summary>
		/// And this one is second
		/// </summary>
		second
	}

	/// <summary>
	/// I'm abstract
	/// <seealso cref="System.Convert"/>
	/// <para>
	/// Another structured info
	/// </para>
	/// <para>
	/// Second structured info
	/// </para>
	/// </summary>
	public abstract class Class2
	{
		/// <summary>
		/// Gets info whether <see cref="Class2"/> is Great <c>true</c>/<c>false</c>
		/// </summary>
		/// <value>Gets the value</value>
		public bool IsGreat { get; }

		/// <summary>
		/// Behold, this is flag property!
		/// </summary>
		public ESomeFlags Flag { get; set; }
	}
}
