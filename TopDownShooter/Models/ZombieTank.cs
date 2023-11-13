using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models
{
	public class ZombieTank : Zombie
	{
		public ZombieTank(Texture2D texture, Vector2 position) : base(texture, position)
		{
			Speed = 250;
			HP = 30;
		}

		public override void TakeDamage(int damage)
		{
			base.TakeDamage(damage);
			CapSpeed();
			Speed -= (damage * 6);
		}

		public override void Update(Player player)
		{
			base.Update(player);
		}

		private void CapSpeed()
		{
			if (Speed <= 170) Speed = 170;
		}

	}
}
