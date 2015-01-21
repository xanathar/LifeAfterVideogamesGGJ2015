using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MoonSharp.Interpreter;
using System.IO;
using MoonSharp.RemoteDebugger;
using System.Diagnostics;

namespace GlobalGameJam2015Presentation
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class GgjPres : Game
	{
		GraphicsDeviceManager graphics;
		MouseState prevMouseState;
		string durationLogFile = null;

		public SpriteBatch SpriteBatch { get; private set; }
		public Table Configuration { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int VrWidth { get; private set; }
		public int VrHeight { get; private set; }
		public Color Background { get; private set; }
		public List<Slide> Slides { get; private set; }
		public LuaApiProvider Api { get; private set; }
		public int SlideIndex { get; private set; }
		public DateTime SlideBirth { get; private set; }
		public DateTime Now { get; private set; }
		public bool LetterBox { get; private set; }
		public InfoWindow SecondScreen { get; private set; }
		public DateTime FirstSlideStart { get; private set; }
		public TimeSpan TotalLength { get; private set; }

		public GgjPres()
			: base()
		{
			MonoGameScriptLoader.InitScriptDefaults();

			Api = new LuaApiProvider(this);

			Slides = new List<Slide>();

			Script cfg = new Script();
			Configuration = cfg.Globals;
			cfg.Globals["defineSlide"] = (Action<Table>)(def => Slides.Add(new Slide(this, def)));

			cfg.DoFile("Config.lua");

			TimeSpan totalLength = TimeSpan.Zero;
			foreach (Slide s in Slides)
			{
				totalLength = totalLength + s.ExpectedRunningLength;
				s.ExpectedRunningLengthTotal = totalLength;
			}

			graphics = new GraphicsDeviceManager(this);

			System.Windows.Forms.Form form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(Configuration.Get("X").ToObject<int>(), Configuration.Get("Y").ToObject<int>());

			Width = Configuration.Get("Width").ToObject<int>();
			Height = Configuration.Get("Height").ToObject<int>();
			VrWidth = Configuration.Get("VirtualWidth").ToObject<int>();
			VrHeight = Configuration.Get("VirtualHeight").ToObject<int>();
			LetterBox = Configuration.Get("VirtualHeight").CastToBool();

			SecondScreen = new InfoWindow();
			TotalLength = TimeSpan.Parse(Configuration.Get("TotalLength").String);

			if (Configuration.Get("SecondScreen").CastToBool())
			{
				SecondScreen.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

				SecondScreen.Location = new System.Drawing.Point(Configuration.Get("SecondScreenX").ToObject<int>(),
					Configuration.Get("SecondScreenY").ToObject<int>());

				SecondScreen.Show();
			}

			durationLogFile = Configuration.Get("LogDurations").String;

			if (durationLogFile != null)
			{
				File.WriteAllText(durationLogFile, "");
			}

			form.Size = new System.Drawing.Size(Width, Height);
			this.Window.IsBorderless = Configuration.Get("Borderless").CastToBool();

			Background = Configuration.Get("Background").ToColor();

			graphics.PreferredBackBufferWidth = Configuration.Get("Width").ToObject<int>();
			graphics.PreferredBackBufferHeight = Configuration.Get("Height").ToObject<int>();

			graphics.ApplyChanges();
			Content.RootDirectory = "Content";

			Now = DateTime.Now;
			SecondScreen.RefreshData(this);
		}





		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		public RenderTarget2D FrameBuffer { get; private set; }

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			FrameBuffer = new RenderTarget2D(GraphicsDevice, VrWidth, VrHeight);
			SpriteBatch = new SpriteBatch(GraphicsDevice);

			foreach (Slide slide in Slides)
				slide.Init();
		}

		private void Click()
		{
			Slides[SlideIndex].Click();
		}

		public void GoPrevSlide()
		{
			if (SlideIndex > 0)
			{
				SlideIndex -= 1;
				ChangeSlide();
			}
		}

		public void GoNextSlide()
		{
			if (SlideIndex < Slides.Count - 1)
			{
				if (durationLogFile != null)
					LogSlideEnd();

				SlideIndex += 1;
				ChangeSlide();
			}
		}

		private void LogSlideEnd()
		{
			List<string> lines = new List<string>();
			lines.Add("---------------------------------------------");
			lines.Add(string.Format("{0} - {1}", SlideIndex, Slides[SlideIndex].Text ?? "<no title>"));

			if (SlideIndex != 0)
			{
				lines.Add(string.Format("Duration : {0}", (this.Now - this.FirstSlideStart).ToString(@"mm\:ss")));
				lines.Add(string.Format("Total Dr : {0}", (this.Now - this.SlideBirth).ToString(@"mm\:ss")));
			}

			File.AppendAllLines(durationLogFile, lines, System.Text.Encoding.UTF8);
		}

		private void ChangeSlide()
		{
			SlideBirth = Now;

			if (FirstSlideStart == DateTime.MinValue)
				FirstSlideStart = Now;

			SecondScreen.RefreshData(this);
			Slides[SlideIndex].Reset();
		}



		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>

		protected override void Update(GameTime gameTime)
		{
			Now = DateTime.Now;

			MouseState mouseState = Mouse.GetState();

			if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
			{
				Click();
			}

			if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
			{
				GoPrevSlide();
			}

			prevMouseState = mouseState;


			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				if (Configuration.Get("AllowExit").CastToBool())
					Exit();
			}

			base.Update(gameTime);
		}


		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.SetRenderTarget(this.FrameBuffer);
			GraphicsDevice.Clear(Background);

			SpriteBatch.Begin();
			Slides[SlideIndex].Draw();
			SpriteBatch.End();

			GraphicsDevice.SetRenderTarget(null);

			GraphicsDevice.Clear(Color.Black);

			SpriteBatch.Begin();

			int letterboxedh = 0;
			int letterboxedy = 0;

			if (LetterBox)
			{
				letterboxedh = (int)(((float)Width) / (((float)VrWidth) / ((float)VrHeight)));
				letterboxedy = (Height - letterboxedh) / 2;
			}

			SpriteBatch.Draw((Texture2D)FrameBuffer, new Rectangle(0, letterboxedy, Width, letterboxedh), Color.White);
			SpriteBatch.End();

			base.Draw(gameTime);
		}







	}
}
