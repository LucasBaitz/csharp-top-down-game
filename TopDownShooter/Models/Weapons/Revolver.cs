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
	public class Revolver : Weapon
	{
		public Revolver(Texture2D texture) : base(texture)
		{
			cooldown = 0.7f;
			maxAmmo = 6;
			Ammo = maxAmmo;
			reloadTime = 0.5f;
		}

		protected override void CreateProjectiles(Player player)
		{
			ProjectileData data = new ProjectileData()
			{
				Texture = projectileTexture,
				Position = player.Position,
				Rotation = player.Rotation,
				Lifespan = 10f,
				Speed = 1500,
				Damage = 6
			};

			ProjectileManager.AddProjectile(data);
		}
	}
}
