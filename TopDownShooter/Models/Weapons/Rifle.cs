using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Managers;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models.Weapons
{
	internal class Rifle : Weapon
	{
		public Rifle(Texture2D texture) : base(texture)
		{
			cooldown = 0.1f;
			maxAmmo = 30;
			Ammo = maxAmmo;
			reloadTime = 1.8f;
		}

		protected override void CreateProjectiles(Player player)
		{
			ProjectileData data = new ProjectileData()
			{
				Texture = projectileTexture,
				Position = player.Position,
				Rotation = player.Rotation,
				Lifespan = 2f,
				Speed = 1500,
				Damage = 1
			};

			ProjectileManager.AddProjectile(data);
		}
	}
}
