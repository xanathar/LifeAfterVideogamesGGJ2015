using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;
using MoonSharp.RemoteDebugger;

namespace GlobalGameJam2015Presentation
{
	public class Slide
	{
		GgjPres m_Presentation;
		Script m_Script;
		Table m_Definition;
		ScriptFunctionDelegate m_Draw;
		ScriptFunctionDelegate m_Reset;
		ScriptFunctionDelegate m_Click;

		public TimeSpan ExpectedRunningLength { get; private set; }
		public TimeSpan ExpectedRunningLengthTotal { get; set; }
		public string Text { get; private set; }
		public string Notes { get; private set; }

		public Slide(GgjPres presentation, Table definition)
		{
			m_Presentation = presentation;
			m_Definition = definition;

			DynValue dur = m_Definition.Get("duration");

			if (dur.Type == DataType.Number)
				ExpectedRunningLength = TimeSpan.FromSeconds(dur.Number);
			else if (dur.Type == DataType.String)
				ExpectedRunningLength = TimeSpan.Parse(dur.String);

			Notes = (m_Definition["notes"] as string) ?? "";
		}

		public void Init()
		{
			string scriptfile = (m_Definition["script"] as string);

			if (scriptfile != null)
			{
				scriptfile = "Slides/" + scriptfile;
			}
			else
			{
				scriptfile = "DefaultSlide.lua";
			}

			m_Script = new Script();

			if (m_Definition.Get("debug").CastToBool())
			{
				RemoteDebuggerService remoteDebugger = new RemoteDebuggerService();
				remoteDebugger.Attach(m_Script, scriptfile);
				Process.Start(remoteDebugger.HttpUrlStringLocalHost);
			}

			m_Presentation.Api.Register(m_Script);

			Text = m_Definition.Get("text").String ?? "";

			m_Script.Globals.Set("_TEXT", DynValue.NewString(Text));

			if (m_Definition.Get("fontsize").IsNotNil())
				m_Script.Globals.Set("_FONTSIZE", m_Definition.Get("fontsize"));
			else
				m_Script.Globals.Set("_FONTSIZE", m_Presentation.Configuration.Get("DefaultSize"));

			if (m_Definition.Get("font").IsNotNil())
				m_Script.Globals.Set("_FONTSIZE", m_Definition.Get("font"));
			else
				m_Script.Globals.Set("_FONT", m_Presentation.Configuration.Get("DefaultFont"));

			Table dst = new Table(m_Script);
			m_Script.Globals.Set("_OPTIONS", DynValue.NewTable(dst));

			if (m_Definition.Get("options").IsNotNil())
			{
				Table src = m_Definition.Get("options").Table;

				foreach (var pair in src.Pairs)
					dst.Set(pair.Key, pair.Value);
			}

			m_Script.DoFile(scriptfile);

			m_Draw = m_Script.Globals.Get("draw").Function.GetDelegate();

			if (m_Script.Globals.Get("click").IsNotNil())
				m_Click = m_Script.Globals.Get("click").Function.GetDelegate();

			if (m_Script.Globals.Get("reset").IsNotNil())
				m_Reset = m_Script.Globals.Get("reset").Function.GetDelegate();
		}


		public void Draw()
		{
			DateTime now = m_Presentation.Now;
			DateTime zero = m_Presentation.SlideBirth;

			TimeSpan time = now - zero;

			try
			{
				m_Draw(time.TotalSeconds);
			}
			catch
			{
				// please never fall here while I'm presenting.. :)
			} 
		}

		public void Click()
		{
			try
			{
				DateTime now = m_Presentation.Now;
				DateTime zero = m_Presentation.SlideBirth;

				TimeSpan time = now - zero;

				if (m_Click != null)
					m_Click(time.TotalSeconds);
				else
					m_Presentation.GoNextSlide();
			}
			catch
			{
				// please never fall here while I'm presenting.. :)
			}
		}

		public void Reset()
		{
			try
			{
				if (m_Reset != null)
					m_Reset();
			}
			catch
			{
				// please never fall here while I'm presenting.. :)
			}
		}

	}
}
