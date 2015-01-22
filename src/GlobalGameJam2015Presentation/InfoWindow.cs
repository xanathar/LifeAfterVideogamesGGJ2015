using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalGameJam2015Presentation
{
	public partial class InfoWindow : Form
	{
		GgjPres m_Pres;

		public InfoWindow()
		{
			InitializeComponent();
		}

		internal void RefreshData(GgjPres ggjPres)
		{
			m_Pres = ggjPres;
			txtNotes.Text = ggjPres.Slides[ggjPres.SlideIndex].Text + "\r\n\r\n" + (ggjPres.Slides[ggjPres.SlideIndex].Notes ?? "---").Replace('\t', ' ');
		}

		private void timerTicker_Tick(object sender, EventArgs e)
		{
			if (m_Pres == null) return;

			if (m_Pres.SlideIndex == 0)
			{
				lblSlide.Text = lblDelta.Text = lblTotal.Text = "--:--";
				return;
			}

			Slide S = m_Pres.Slides[m_Pres.SlideIndex];

			TimeSpan slideTime = m_Pres.Now - m_Pres.SlideBirth;

			FormatTime(lblSlide, S.ExpectedRunningLength - slideTime);

			TimeSpan totalTime = m_Pres.Now - m_Pres.FirstSlideStart;

			FormatTime(lblDelta, S.ExpectedRunningLengthTotal - totalTime);
			FormatTime(lblTotal, m_Pres.TotalLength - totalTime);
		}

		void FormatTime(Label lbl, TimeSpan ts)
		{
			lbl.ForeColor = ts.TotalSeconds > 0 ? Color.Black : Color.Red;

			lbl.Text = ts.ToString(@"mm\:ss");

		}

	}
}
