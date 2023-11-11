using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TopDownShooter.Models;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Managers
{
	public class ProjectileManager
	{
		public static List<Projectile> Projectiles { get; } = new List<Projectile>();
		private static BloodManager _bloodManager;

		public static void Init()
		{
			_bloodManager = new BloodManager();
		}

		public static void AddProjectile(ProjectileData data)
		{
			Projectiles.Add(new Projectile(data.Texture, data));
		}

		public static void Update(List<Zombie> zombies)
		{
			_bloodManager.Update();

			foreach (Projectile proj in Projectiles)
			{
				proj.Update();
				foreach (Zombie z in zombies)
				{
					if (z.HP <= 0) continue;
					if ((proj.Position - z.Position).Length() < 32)
					{
						z.TakeDamage(proj.Damage);
						_bloodManager.SpawnBlood(z.Position);
						proj.Damage -= 1;
						
						if(proj.Damage <= z.HP)
						{
							proj.Destroy();
						}
						
						break;
					}
				}
			}

			Projectiles.RemoveAll(projs => projs.Lifespan <= 0);
		}

		public static void Draw()
		{
			_bloodManager?.Draw();
			foreach (Projectile proj in Projectiles)
			{
				proj.Draw();
			}
		}

		public static void Reset()
		{
			Projectiles.Clear();
		}
	}
}
