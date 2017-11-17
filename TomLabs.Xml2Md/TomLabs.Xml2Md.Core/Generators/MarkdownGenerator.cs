using System;
using System.Collections.Generic;
using System.Linq;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Elements.Refs.Crefs;
using TomLabs.Xml2Md.Core.Elements.Refs.NameRefs;
using TomLabs.Xml2Md.Core.Elements.RichInfos;
using TomLabs.Xml2Md.Core.Elements.RichInfos.Params;
using TomLabs.Xml2Md.Core.Extensions;

namespace TomLabs.Xml2Md.Core.Generators
{
	/// <summary>
	/// Class used to generate markdown text from Element tree
	/// </summary>
	public class MarkdownGenerator : IDocGenerator
	{
		public Element DocumentRoot { get; private set; }

		public string AssemblyName { get; private set; }

		#region Element Styles

		public Dictionary<Type, Func<Element, string>> ElementStyles =>
			new Dictionary<Type, Func<Element, string>>
			{
				[typeof(Doc)] =
					(elm) => $"# {elm.ToString()}\n{elm.ChildElements.Render(ElementStyles)}",
				[typeof(Member)] =
					(elm) => $"{TypeToHeading(elm)} {((Member)elm).ReferenceType} {elm.ToString()}\n{elm.ChildElements.Render(ElementStyles)}\n***\n",
				[typeof(Example)] =
					(elm) => $"Example\n```cs\n{elm.ToString()}\n```\n",
				[typeof(C)] =
					(elm) => $"`{elm.ToString()}`",
				[typeof(Value)] =
					(elm) => $"Value {elm.ToString()}\n",
				[typeof(See)] =
					(elm) => $"[{((See)elm).ReferenceValue.SplitNamespace().Last()}]({((See)elm).ReferenceValue})\n",
				[typeof(SeeAlso)] =
					(elm) => $"[{((SeeAlso)elm).ReferenceValue.SplitNamespace().Last()}]({((SeeAlso)elm).ReferenceValue})\n",
				[typeof(ParamRef)] =
					(elm) => $"`{((ParamRef)elm).ReferenceName}`\n",
				[typeof(TypeParamRef)] =
					(elm) => $"`{((TypeParamRef)elm).ReferenceName}`\n",

				#region Rich Infos
				[typeof(Summary)] =
					(elm) => $"{elm.ToString(ElementStyles)}\n",
				[typeof(Returns)] =
					(elm) => $"*Returns* {elm.ToString(ElementStyles)}\n",
				[typeof(Remarks)] =
					(elm) => $"Remarks {elm.ToString(ElementStyles)}\n",
				[typeof(Para)] =
					(elm) => $"Para {elm.ToString(ElementStyles)}",
				[typeof(Param)] =
					(elm) => $"Param {((Param)elm).ReferenceName} {elm.ToString(ElementStyles)}\n",
				[typeof(TypeParam)] =
					(elm) => $"TypeParam {((TypeParam)elm).ReferenceName} {elm.ToString(ElementStyles)}\n",
				[typeof(Elements.Refs.Crefs.Exception)] =
					(elm) => $"Exception {((Elements.Refs.Crefs.Exception)elm).ReferenceValue} {elm.ToString(ElementStyles)}\n",
				[typeof(Permission)] =
					(elm) => $"Permission {((Permission)elm).ReferenceValue} {elm.ToString(ElementStyles)}\n",
				#endregion

				[typeof(Element)] =
					(elm) => $"{elm.ToString()}\n",
			};

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentRoot">Generated element tree</param>
		public MarkdownGenerator(Element documentRoot)
		{
			DocumentRoot = documentRoot;

			if (DocumentRoot is Doc)
			{
				var doc = DocumentRoot as Doc;
				AssemblyName = doc.AssemblyName;
			}
		}

		/// <summary>
		/// Renders markdown from <see cref="DocumentRoot"/>
		/// </summary>
		/// <returns></returns>
		public string Render()
		{
			return DocumentRoot.Render(ElementStyles);
		}

		private string TypeToHeading(Element element)
		{
			if (element is Member)
			{
				var member = element as Member;
				switch (member.ReferenceType)
				{
					case EReferenceType.Type: return "##";
					case EReferenceType.Method: return "###";
					case EReferenceType.Property: return "###";
					case EReferenceType.Field: return "####";
					case EReferenceType.Event: return "####";
				}
			}

			return string.Empty;
		}
	}
}
