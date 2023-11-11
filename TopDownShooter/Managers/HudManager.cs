using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Helpers;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
	public static class HudManager
	{
		private static Texture2D _ammoTexture;
		private static Texture2D _healthTexture;
		private static SpriteFont _font;

		public static void Init(Texture2D ammoTexture, Texture2D healthTexture, SpriteFont font)
		{
			_ammoTexture = ammoTexture;
			_healthTexture = healthTexture;
			_font = font;
		}

		public static void Draw(Player player)
		{
			AmmoHud(player);
			//RuntimeHud();
			HealthHud(player);
		}

		public static void AmmoHud(Player player)
		{
			Color c = player.CurrentWeapon.IsReloading ? Color.Red : Color.White;

			for (int i = 0; i < player.CurrentWeapon.Ammo; i++)
			{
				Vector2 position = new Vector2(0, i * _ammoTexture.Height * 2);
				Globals.SpriteBatch.Draw(_ammoTexture, position, null, c * 0.75f, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
			}
		}

		public static void RuntimeHud()
		{
			string runtimeText = $"TEXT";
			Vector2 runtimePosition = new Vector2((Globals.Bounds.X / 2) / 2, 0);
			Globals.SpriteBatch.DrawString(_font, runtimeText, runtimePosition, Color.White);
		}

		public static void HealthHud(Player player)
		{
			float totalHeight = player.HP * _healthTexture.Height * 2;

			Vector2 position = new Vector2(0, Globals.Bounds.Y - totalHeight);

			for (int i = 0; i < player.HP; i++)
			{
				Globals.SpriteBatch.Draw(_healthTexture, position, null, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
				position.Y += _healthTexture.Height * 2;
			}
		}
	}
}
