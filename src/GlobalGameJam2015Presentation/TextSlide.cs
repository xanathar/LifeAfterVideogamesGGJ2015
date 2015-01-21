using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam2015Presentation
{
	public class TextSlide : ISlide
	{
		GgjPres m_Presentation;
		Sprite m_Sprite;
		string m_Text;

		public TextSlide(GgjPres presentation, string text)
		{
			m_Presentation = presentation;
			m_Text = text;
		}

		public void Init()
		{
			m_Sprite = Sprite.CreateTextSprite(m_Presentation, m_Text, m_Presentation.Configuration.Get("DefaultFont").String,
				(float)m_Presentation.Configuration.Get("DefaultSize").Number);
		}

		public void Draw()
		{
			m_Sprite.Draw();
		}

		public void Click()
		{
			m_Presentation.GoNextSlide();
		}
	}
}
