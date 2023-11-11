﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopDownShooter.Helpers;
using TopDownShooter.Managers;

namespace TopDownShooter
{
	public class Game1 : Game
	{
		private GameManager _gameManager;
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			Globals.Bounds = new(1600, 900);
			_graphics.PreferredBackBufferWidth = Globals.Bounds.X;
			_graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
			_graphics.ApplyChanges();


			Globals.Content = Content;
			_gameManager = new();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			Globals.SpriteBatch = _spriteBatch;
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			Globals.Update(gameTime);
			_gameManager.Update();


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.DarkGray);

			_spriteBatch.Begin();
			_gameManager.Draw();
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}