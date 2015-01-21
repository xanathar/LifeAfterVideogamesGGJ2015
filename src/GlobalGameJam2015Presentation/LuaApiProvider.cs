using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter;

namespace GlobalGameJam2015Presentation
{
	public class LuaApiProvider
	{
		private GgjPres m_Presentation;

		static LuaApiProvider()
		{
			UserData.RegisterType<Sprite>();
		}

		public LuaApiProvider(GgjPres presentation)
		{
			this.m_Presentation = presentation;
		}

		internal void Register(Script script)
		{
			script.Globals["next"] = (Action)m_Presentation.GoNextSlide;
			script.Globals["prev"] = (Action)m_Presentation.GoPrevSlide;
			script.Globals["text"] = (Func<string, string, float, Sprite>)CreateText;
			script.Globals["sprite"] = (Func<string, Sprite>)CreateSprite;
		}

		public Sprite CreateSprite(string filename)
		{
			return Sprite.CreateImageSprite(m_Presentation, filename);
		}

		public Sprite CreateText(string text, string face = null, float size = -1)
		{
			return Sprite.CreateTextSprite(m_Presentation, text,
				face ?? m_Presentation.Configuration.Get("DefaultFont").String,
				(size > 0) ? size : (float)m_Presentation.Configuration.Get("DefaultSize").Number);
		}

		













	}
}
