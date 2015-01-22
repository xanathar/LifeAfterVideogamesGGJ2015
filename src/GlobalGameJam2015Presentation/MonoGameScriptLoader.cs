using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace GlobalGameJam2015Presentation
{
	class MonoGameScriptLoader : ClassicLuaScriptLoader
	{ 
		protected override bool FileExists(string file)
		{
			using (var stream = TitleContainer.OpenStream("Scripts/" + file))
				return stream != null;
		}

		public override string LoadFile(string file, Table globalContext)
		{
			using (var stream = TitleContainer.OpenStream("Scripts/" + file))
			{
				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}

		public static void InitScriptDefaults()
		{
			Script.DefaultOptions.ScriptLoader = new MonoGameScriptLoader();
			Script.DefaultOptions.DebugPrint = ss => System.Diagnostics.Debug.WriteLine("[SCRIPT] : " + ss);
		}

		internal static Script CreateScript()
		{
			return new Script(CoreModules.Preset_SoftSandbox | CoreModules.LoadMethods);
		}
	} 
}
