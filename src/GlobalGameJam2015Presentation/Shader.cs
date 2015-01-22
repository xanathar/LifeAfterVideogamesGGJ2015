using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalGameJam2015Presentation
{
	public class Shader
	{
		private Effect m_Fx;
		GgjPres m_Presentation;

		public Shader(GgjPres presentation, Effect fx)
		{
			m_Presentation = presentation;
			m_Fx = fx;
		}

		public static Shader LoadFromFile(GgjPres presentation, string fxfile)
		{
			Effect fx = presentation.Content.Load<Effect>(fxfile);
			return new Shader(presentation, fx);
		}

		public void Set(string paramName, float value)
		{
			m_Fx.Parameters[paramName].SetValue(value);
		}

		public void On()
		{
			m_Fx.CurrentTechnique.Passes[0].Apply();
		}

		public void Off()
		{
			m_Presentation.StandardFx.CurrentTechnique.Passes[0].Apply();
		}

	}

}
