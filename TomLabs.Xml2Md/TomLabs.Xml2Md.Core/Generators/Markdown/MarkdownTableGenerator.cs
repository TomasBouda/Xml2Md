using System;
using System.Collections.Generic;
using TomLabs.Xml2Md.Core.Elements;
using TomLabs.Xml2Md.Core.Elements.Refs.Crefs;
using TomLabs.Xml2Md.Core.Elements.RichInfos.Params;

namespace TomLabs.Xml2Md.Core.Generators.Markdown
{
	public static class MarkdownTableGenerator
	{
		private static Type LastElementType { get; set; }
		private static int ElementCount { get; set; }

		public static string Render(Element elm, Dictionary<Type, Func<Element, string>> styles)
		{
			if (LastElementType != elm.GetType())
			{
				LastElementType = elm.GetType();
				return RenderHeading(elm) + Render(elm, styles);
			}

			if (elm is Param || elm is TypeParam)
			{
				var param = elm as Param;
				LastElementType = param.GetType();

				return $"{param.ReferenceName} | {param.ToString(styles)}\n";
			}
			else if (elm is Elements.Refs.Crefs.Exception)
			{
				var ex = elm as Elements.Refs.Crefs.Exception;
				LastElementType = ex.GetType();

				return $"`{ex.ReferenceValue}` | {ex.ToString(styles)}\n";
			}
			else if (elm is Permission)
			{
				var p = elm as Permission;
				LastElementType = p.GetType();

				return $"`{p.ReferenceValue}` | {p.ToString(styles)}\n";
			}

			return string.Empty;
		}

		private static string RenderHeading(Element elm)
		{
			return $"\n\n{elm.GetType().Name} name | Description\n--- | ---\n";
		}
	}
}
