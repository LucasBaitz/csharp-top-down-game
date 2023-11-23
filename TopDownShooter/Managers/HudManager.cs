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
			RoundHud();
			HealthHud(player);
			KillCountHud(player);
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

		public static void RoundHud()
		{
			string roundText = $"{RoundsManager.RoundCounter}";
			Vector2 counterPosition = new Vector2(Globals.Bounds.X / 2, 0);
			Globals.SpriteBatch.DrawString(_font, roundText, counterPosition, Color.White);
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

		public static void KillCountHud(Player player)
		{
			string killCount = $"{player.KillCount} / {RoundsManager.KillsToNextRound}";
			Vector2 position = new Vector2(Globals.Bounds.X - 150, 0);

			Globals.SpriteBatch.DrawString(_font, killCount, position, Color.White);
		}
	}
}
