using Microsoft.Xna.Framework.Graphics;
using System;
using TopDownShooter.Helpers;
using TopDownShooter.Managers;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models.Weapons
{
	public class Shotgun : Weapon
	{
		private const float ANGLE_STEP = (float)(Math.PI / 40);
		public int ShellCapacity { get; private set; } = 5;

		public Shotgun(Texture2D projectileTexture) : base(projectileTexture)
		{
			cooldown = 0.7f;
			maxAmmo = 7;
			Ammo = maxAmmo;
			reloadTime = 3f;
		}

		protected override void CreateProjectiles(Player player)
		{
			ProjectileData pd = new()
			{
				Texture = projectileTexture,
				Position = player.Position,
				Rotation = player.Rotation - (3 * ANGLE_STEP),
				Lifespan = 0.5f,
				Speed = 800,
				Damage = 2
			};

			for (int i = 0; i < ShellCapacity; i++)
			{
				pd.Rotation += ANGLE_STEP;
				pd.Speed = BulletVelocity();
				ProjectileManager.AddProjectile(pd);
			}
		}

		private int BulletVelocity()
		{
			var rdn = new Random();
			return rdn.Next(500, 800);
		}
	}
}
