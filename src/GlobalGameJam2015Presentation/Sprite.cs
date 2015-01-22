using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalGameJam2015Presentation
{
	public class Sprite
	{
		private Texture2D m_Texture;
		GgjPres m_Presentation;

		public Sprite(GgjPres presentation, Texture2D texture)
		{
			m_Presentation = presentation;
			m_Texture = texture;
		}

		public void Blit(int sx, int sy, int w, int h, int dx, int dy, float opacity = 1f)
		{
			float alpha = Math.Max(0, Math.Min(1f, opacity));
			m_Presentation.SpriteBatch.Draw(m_Texture, new Rectangle(dx, dy, w, h), new Rectangle(sx, sy, w, h), Color.White * alpha);
		}


		public void Stretch(int x, int y, int w, int h, float opacity = 1f)
		{
			float alpha = Math.Max(0, Math.Min(1f, opacity));
			m_Presentation.SpriteBatch.Draw(m_Texture, new Rectangle(x, y, w, h), Color.White * alpha);
		}

		public void Draw(int x = 0, int y = 0, float opacity = 1f)
		{
			float alpha = Math.Max(0, Math.Min(1f, opacity));
			m_Presentation.SpriteBatch.Draw(m_Texture, new Vector2(x, y), Color.White * alpha);
		}

		static int counter = 0;

		internal static Sprite CreateTextSprite(GgjPres presentation, string text, string face, float size)
		{
			var strfmt = new System.Drawing.StringFormat();
			strfmt.Alignment = System.Drawing.StringAlignment.Center;
			strfmt.LineAlignment = System.Drawing.StringAlignment.Center;

			using (var font = new System.Drawing.Font(face, size))
			using (var bmp = new System.Drawing.Bitmap(presentation.VrWidth, presentation.VrHeight))
			{
				using (var gfx = System.Drawing.Graphics.FromImage(bmp))
				{
					gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

					gfx.DrawString(text, font,
						System.Drawing.Brushes.White,
						new System.Drawing.RectangleF(0, 0, presentation.VrWidth, presentation.VrHeight), strfmt);
				}

				using (var stream = new System.IO.MemoryStream())
				{
					bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

					bmp.Save(string.Format(@"C:\temp\pres\text{0}.png", counter++), System.Drawing.Imaging.ImageFormat.Png);

					var tex = Texture2D.FromStream(presentation.GraphicsDevice, stream);
					return new Sprite(presentation, tex);
				}
			}
		}


		internal static Sprite CreateImageSprite(GgjPres presentation, string filename)
		{
			Texture2D tx = presentation.Content.Load<Texture2D>(filename);
			return new Sprite(presentation, tx);
		}
	}
}
