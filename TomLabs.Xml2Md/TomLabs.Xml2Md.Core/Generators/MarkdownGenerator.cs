using System;
using System.Collections.Generic;
using System.Text;
using TomLabs.Shadowgem.Extensions.String;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Elements.Refs.Crefs;
using TomLabs.Xml2Md.Core.Elements.Refs.NameRefs;
using TomLabs.Xml2Md.Core.Elements.RichInfos;
using TomLabs.Xml2Md.Core.Elements.RichInfos.Params;

namespace TomLabs.Xml2Md.Core.Generators
{
	internal static class ElementExtensions
	{
		public static string Render(this Element element, Dictionary<Type, Func<Element, string>> styles)
		{
			styles.TryGetValue(element.GetType(), out var format);
			return format(element) + (element.ChildElements.Count > 0 ? element.ChildElements.Render(styles) : "");
		}

		public static string Render(this List<Element> element, Dictionary<Type, Func<Element, string>> styles)
		{
			var sb = new StringBuilder();
			foreach (var elem in element)
			{
				sb.Append(elem.Render(styles));
			}
			return sb.ToString();
		}

		public static string RenderInside(this string s, List<Element> childs, Dictionary<Type, Func<Element, string>> styles)
		{
			var output = new List<string>();
			foreach (var child in childs)
			{
				styles.TryGetValue(child.GetType(), out var format);
				output.Add(format(child));
			}
			return s.FillIn(output.ToArray());
		}
	}

	public class MarkdownGenerator
	{
		private Element DocumentRoot { get; set; }

		public string AssemblyName { get; private set; }

		#region Element Styles

		private Dictionary<Type, Func<Element, string>> ElementStyles =>
			new Dictionary<Type, Func<Element, string>>
			{
				[typeof(Doc)] =
					(elm) => $"# {elm.ToString()}\n",
				[typeof(Member)] =
					(elm) => $"## {elm.ToString().Trim()}\n",
				[typeof(Example)] =
					(elm) => $"```cs\n{elm.ToString()}\n```\n",
				[typeof(C)] =
					(elm) => $"`{elm.ToString()}`",
				[typeof(Value)] =
					(elm) => $"Value {elm.ToString()}\n",
				[typeof(See)] =
					(elm) => $"See {((See)elm).ReferenceValue}\n",
				[typeof(SeeAlso)] =
					(elm) => $"SeeAlso {((SeeAlso)elm).ReferenceValue}\n",
				[typeof(ParamRef)] =
					(elm) => $"ParamRef {((ParamRef)elm).ReferenceName}\n",
				[typeof(TypeParamRef)] =
					(elm) => $"TypeParamRef {((TypeParamRef)elm).ReferenceName}\n",

				#region Rich Infos
				[typeof(Summary)] =
					(elm) => $"Summary {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(Returns)] =
					(elm) => $"Returns {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(Remarks)] =
					(elm) => $"Remarks {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(Para)] =
					(elm) => $"Para {elm.ToString(ElementStyles).Trim()}",
				[typeof(Param)] =
					(elm) => $"Param {((Param)elm).ReferenceName} {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(TypeParam)] =
					(elm) => $"TypeParam {((TypeParam)elm).ReferenceName} {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(Elements.Refs.Crefs.Exception)] =
					(elm) => $"Exception {((Elements.Refs.Crefs.Exception)elm).ReferenceValue} {elm.ToString(ElementStyles).Trim()}\n",
				[typeof(Permission)] =
					(elm) => $"Permission {((Permission)elm).ReferenceValue} {elm.ToString(ElementStyles).Trim()}\n",
				#endregion

				[typeof(Element)] =
					(elm) => $"{elm.ToString()}\n",
			};

		#endregion

		public MarkdownGenerator(Element documentRoot)
		{
			DocumentRoot = documentRoot;
		}

		public string Render()
		{
			return DocumentRoot.Render(ElementStyles);
		}
	}
}
