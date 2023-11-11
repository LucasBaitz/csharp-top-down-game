using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Managers;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models.Weapons
{
	public class Pistol : Weapon
	{

		public Pistol(Texture2D texture) : base(texture)
		{
			cooldown = 0.3f;
			maxAmmo = 12;
			Ammo = maxAmmo;
			reloadTime = 1f;
		}

		protected override void CreateProjectiles(Player player)
		{
			ProjectileData data = new ProjectileData()
			{
				Texture = projectileTexture,
				Position = player.Position,
				Rotation = player.Rotation,
				Lifespan = 3f,
				Speed = 1000,
				Damage = 1
			};

			ProjectileManager.AddProjectile(data);
		}
	}
}
