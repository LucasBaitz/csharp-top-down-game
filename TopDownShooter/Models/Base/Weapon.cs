using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Helpers;

namespace TopDownShooter.Models.Base
{
	public abstract class Weapon
	{
		protected float cooldown;
		protected float cooldownLeft;
		protected int maxAmmo;
		public int Ammo { get; protected set; }
		protected readonly Texture2D projectileTexture;
		protected float reloadTime;
		public bool IsReloading { get; protected set; }

		protected Weapon(Texture2D texture)
		{
			cooldownLeft = 0f;
			IsReloading = false;
			projectileTexture = texture;
		}

		public virtual void Reload()
		{
			if (IsReloading || (Ammo == maxAmmo)) return;
			cooldownLeft = reloadTime;
			IsReloading = true;
			Ammo = maxAmmo;
		}

		protected abstract void CreateProjectiles(Player player);

		public virtual void Shoot(Player player)
		{
			if (cooldownLeft > 0 || IsReloading) return;

			Ammo--;
			if (Ammo > 0)
			{
				cooldownLeft = cooldown;
			}
			else
			{
				Reload();
			}

			CreateProjectiles(player);
		}

		public virtual void Update()
		{
			if (cooldownLeft > 0)
			{
				cooldownLeft -= Globals.TotalSeconds;
			}
			else if (IsReloading)
			{
				IsReloading = false;
			}
		}
	}
}
