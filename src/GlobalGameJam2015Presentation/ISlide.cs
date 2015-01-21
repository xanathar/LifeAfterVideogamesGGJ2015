using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam2015Presentation
{
	public interface ISlide
	{
		void Init();
		void Draw();
		void Click();
	}
}
