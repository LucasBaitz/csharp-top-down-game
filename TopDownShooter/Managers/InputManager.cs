using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace TopDownShooter.Managers
{
	public static class InputManager
	{
		private static MouseState _lastMouseState;
		private static KeyboardState _lastKeyboardState;
		private static Vector2 _direction;
		private static int _lastNumberKeyPressed; // New property to store the last pressed number key

		public static Vector2 Direction => _direction;
		public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
		public static bool MouseGotClicked { get; private set; }
		public static bool MouseRightGotClicked { get; private set; }
		public static bool MouseLeftDown { get; private set; }

		// New property to get the last pressed number key
		public static int LastNumberKeyPressed => _lastNumberKeyPressed;

		public static void Update()
		{
			var keyboardState = Keyboard.GetState();

			_direction = Vector2.Zero;
			if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
			if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
			if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
			if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;

			MouseLeftDown = Mouse.GetState().LeftButton == ButtonState.Pressed;
			MouseGotClicked = MouseLeftDown && _lastMouseState.LeftButton == ButtonState.Released;
			MouseRightGotClicked = Mouse.GetState().RightButton == ButtonState.Pressed
								   && _lastMouseState.RightButton == ButtonState.Released;

			for (int i = 1; i <= 5; i++)
			{
				Keys numberKey = (Keys)Enum.Parse(typeof(Keys), "D" + i);
				if (keyboardState.IsKeyDown(numberKey) && _lastKeyboardState.IsKeyUp(numberKey))
				{
					_lastNumberKeyPressed = i;
				}
			}

			_lastMouseState = Mouse.GetState();
			_lastKeyboardState = keyboardState;
		}
	}

}
