using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;

namespace GlobalGameJam2015Presentation
{
	public class ScriptSlide : ISlide
	{
		GgjPres m_Presentation;
		Script m_Script;
		string m_Filename;
		ScriptFunctionDelegate m_Draw;
		ScriptFunctionDelegate m_Click;

		public ScriptSlide(GgjPres presentation, string filename)
		{
			m_Presentation = presentation;
			m_Filename = filename;
		}

		public void Init()
		{
			m_Script = new Script(CoreModules.Preset_SoftSandbox);

			m_Presentation.Api.Register(m_Script);

			m_Script.DoFile(m_Filename);

			m_Draw = m_Script.Globals.Get("draw").Function.GetDelegate();

			if (m_Script.Globals.Get("click").IsNotNil())
				m_Click = m_Script.Globals.Get("click").Function.GetDelegate();
		}


		public void Draw()
		{
			DateTime now = m_Presentation.Now;
			DateTime zero = m_Presentation.SlideBirth;

			TimeSpan time = now - zero;

			m_Draw(time.TotalSeconds);
		}

		public void Click()
		{
			if (m_Click != null)
				m_Click();
			else
				m_Presentation.GoNextSlide();
		}



	}
}
