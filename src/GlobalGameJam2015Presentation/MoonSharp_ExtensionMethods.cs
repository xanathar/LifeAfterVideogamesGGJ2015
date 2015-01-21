using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;

namespace GlobalGameJam2015Presentation
{
	static class MoonSharp_ExtensionMethods
	{
		public static Color ToColor(this DynValue value)
		{
			System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(value.String);
			return new Color(color.R, color.G, color.B);
		}
	}
}
