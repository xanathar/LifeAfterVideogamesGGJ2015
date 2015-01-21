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

namespace GlobalGameJam2015Presentation
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class GgjPres : Game
	{
		GraphicsDeviceManager graphics;
		MouseState prevMouseState;

		public SpriteBatch SpriteBatch { get; private set; }
		public Table Configuration { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int VrWidth { get; private set; }
		public int VrHeight { get; private set; }
		public Color Background { get; private set; }
		public List<ISlide> Slides { get; private set; }
		public LuaApiProvider Api { get; private set; }
		public int SlideIndex { get; private set; }
		public DateTime SlideBirth { get; private set; }
		public DateTime Now { get; private set; }

		public GgjPres()
			: base()
		{
			MonoGameScriptLoader.InitScriptDefaults();

			Api = new LuaApiProvider(this);

			Slides = new List<ISlide>();

			Script cfg = new Script();
			Configuration = cfg.Globals;
			cfg.Globals["script"] = (Action<string>)(s => Slides.Add(new ScriptSlide(this, "Slides/" + s)));
			cfg.Globals["text"] = (Action<string>)(s => Slides.Add(new TextSlide(this, s)));

			cfg.DoFile("Config.lua");

			graphics = new GraphicsDeviceManager(this);

			System.Windows.Forms.Form form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
			form.Location = new System.Drawing.Point(Configuration.Get("X").ToObject<int>(), Configuration.Get("Y").ToObject<int>());

			Width = Configuration.Get("Width").ToObject<int>();
			Height = Configuration.Get("Height").ToObject<int>();
			VrWidth = Configuration.Get("VirtualWidth").ToObject<int>();
			VrHeight = Configuration.Get("VirtualHeight").ToObject<int>();


			form.Size = new System.Drawing.Size(Width, Height);
			this.Window.IsBorderless = Configuration.Get("Borderless").CastToBool();

			Background = Configuration.Get("Background").ToColor();

			graphics.PreferredBackBufferWidth = Configuration.Get("Width").ToObject<int>();
			graphics.PreferredBackBufferHeight = Configuration.Get("Height").ToObject<int>();

			graphics.ApplyChanges();
			Content.RootDirectory = "Content";
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

			foreach (ISlide slide in Slides)
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
				SlideIndex += 1;
				ChangeSlide();
			}
		}

		private void ChangeSlide()
		{
			SlideBirth = Now;
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
			SpriteBatch.Draw((Texture2D)FrameBuffer, new Rectangle(0, 0, Width, Height), Color.White);
			SpriteBatch.End();

			base.Draw(gameTime);
		}






	}
}
