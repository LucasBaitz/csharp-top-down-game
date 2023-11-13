using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Helpers;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
	public class GameManager
	{
		private readonly Player _player;
		private readonly TileMap _tileMap;
		public GameManager()
		{
			var bulletTexture = Globals.Content.Load<Texture2D>("bullet");
			var healthTexture = Globals.Content.Load<Texture2D>("health");
			var font = Globals.Content.Load<SpriteFont>("font");


			HudManager.Init(bulletTexture, healthTexture, font);
			RoundsManager.Init();
			PlayerSpriteManager.Init();
			WeaponsManager.Init();
			ProjectileManager.Init();
			ZombieManager.Init();
			ZombieManager.AddZombie();
			
			_player = new Player(PlayerSpriteManager.CurrentSprite, new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2));
			_tileMap = new TileMap();
		}

		public void Update()
		{
			InputManager.Update();
			ProjectileManager.Update(ZombieManager.Zombies);
			ZombieManager.Update(_player);
			RoundsManager.Update(_player);
			_player.Update(ZombieManager.Zombies);

			if (_player.IsDead) Restart();
		}

		public void Draw()
		{
			_tileMap.Draw();
			HudManager.Draw(_player);
			ProjectileManager.Draw();
			ZombieManager.Draw();
			_player.Draw();
			
		}

		public void Restart()
		{
			ProjectileManager.Reset();
			WeaponsManager.Reset();
			ZombieManager.Reset();
			RoundsManager.Reset();
			_player.Reset();
		}
	}
}
