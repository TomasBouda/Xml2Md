using System;
using System.Collections.Generic;
using System.Linq;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Elements.Refs.Crefs;
using TomLabs.Xml2Md.Core.Elements.Refs.NameRefs;
using TomLabs.Xml2Md.Core.Elements.RichInfos;
using TomLabs.Xml2Md.Core.Elements.RichInfos.Params;
using TomLabs.Xml2Md.Core.Extensions;

namespace TomLabs.Xml2Md.Core.Generators.Markdown
{
	/// <summary>
	/// Class used to generate markdown text from Element tree
	/// </summary>
	public class MarkdownGenerator : IDocGenerator
	{
		public Element DocumentRoot { get; private set; }

		/// <summary>
		/// Assembly name of given <see cref="Doc"/> element
		/// </summary>
		public string AssemblyName { get; private set; }

		/// <summary>
		/// Gets or sets whether to render type icons. e.g. :red_circle:
		/// </summary>
		public bool RenderIcons { get; set; }

		#region Element Styles

		public ElementStyles ElementStyles =>
			new ElementStyles(
				new Dictionary<Type, Func<Element, string>>
				{
					[typeof(Doc)] =
						(elm) => $"# {elm.ToString()}\n{elm.ChildElements.Render(ElementStyles)}",
					[typeof(Member)] =
						(elm) => $"{TypeToHeading(elm)} *{((Member)elm).ReferenceType}* {elm.ToString().Replace($"{AssemblyName}.", "")}\n" +
									$"{elm.ChildElements.Render(ElementStyles)}\n***\n",
					[typeof(Example)] =
						(elm) => $"*Example*\n```cs{elm.ToString()}```\n",
					[typeof(C)] =
						(elm) => $"`{elm.ToString()}`",
					[typeof(Value)] =
						(elm) => $"Value {elm.ToString()}\n",
					[typeof(See)] =
						(elm) => $"[{elm.ToString().SplitNamespace().Last()}]({elm.ToString()})\n",
					[typeof(SeeAlso)] =
						(elm) => $"[{elm.ToString().SplitNamespace().Last()}]({elm.ToString()})\n",
					[typeof(ParamRef)] =
						(elm) => $"`{elm.ToString()}`",
					[typeof(TypeParamRef)] =
						(elm) => $"`{elm.ToString()}`",

					#region Rich Infos
					[typeof(Summary)] =
						(elm) => $"{elm.ToString(ElementStyles)}\n",
					[typeof(Returns)] =
						(elm) => $"\n**Returns:** {elm.ToString(ElementStyles)}\n",
					[typeof(Remarks)] =
						(elm) => $"{elm.ToString(ElementStyles)}\n",
					[typeof(Para)] =
						(elm) => $"{elm.ToString(ElementStyles)}\n",
					[typeof(Param)] =
						(elm) => MarkdownTableGenerator.Render(elm, "Param", $"{((Param)elm).ReferenceName} | {elm.ToString(ElementStyles)}\n"),
					[typeof(TypeParam)] =
						(elm) => MarkdownTableGenerator.Render(elm, "Type Param", $"{((TypeParam)elm).ReferenceName} | {elm.ToString(ElementStyles)}\n"),
					[typeof(Elements.Refs.Crefs.Exception)] =
						(elm) => MarkdownTableGenerator.Render(elm, "Exception", $"`{((Elements.Refs.Crefs.Exception)elm).ReferenceValue}` | {elm.ToString(ElementStyles)}\n"),
					[typeof(Permission)] =
						(elm) => MarkdownTableGenerator.Render(elm, "Permission", $"`{((Permission)elm).ReferenceValue}` | {elm.ToString(ElementStyles)}\n"),
					#endregion

					[typeof(Element)] =
						(elm) => $"{elm.ToString()}\n",
				},
				(e) => MarkdownTableGenerator.ResetIf(e)
			);

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentRoot">Generated element tree</param>
		public MarkdownGenerator(Element documentRoot, bool renderIcons = true)
		{
			DocumentRoot = documentRoot;
			RenderIcons = renderIcons;

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
					case EReferenceType.Type: return $"## {(RenderIcons ? ":red_circle:" : "")}";
					case EReferenceType.Method: return $"### {(RenderIcons ? ":small_blue_diamond:" : "")}";
					case EReferenceType.Property: return $"### {(RenderIcons ? ":small_orange_diamond:" : "")}";
					case EReferenceType.Field: return $"#### {(RenderIcons ? ":small_red_triangle:" : "")}";
					case EReferenceType.Event: return $"#### {(RenderIcons ? ":small_red_triangle_down:" : "")}";
				}
			}

			return string.Empty;
		}
	}
}
