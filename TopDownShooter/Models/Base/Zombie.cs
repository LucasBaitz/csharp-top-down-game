using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TopDownShooter.Helpers;

namespace TopDownShooter.Models.Base
{
	public class Zombie : Sprite
	{
		public int HP { get; set; } = 2;
		public bool IsDead => CheckDeath();
        public Zombie(Texture2D texture, Vector2 position) : base(texture, position)
		{
			Speed = 100;
		}

		public Zombie(Texture2D texture, Vector2 position, int speed) : base(texture, position)
		{
			Speed = speed;
		}

		public virtual void TakeDamage(int damage)
		{
			HP -= damage;
		}

		private bool CheckDeath()
		{
			return HP <= 0;
		}

		public virtual void Update(Player player)
		{
			var playerPos = player.Position - Position;

			Rotation = (float)Math.Atan2(playerPos.Y, playerPos.X);

			if (playerPos.Length() > 4)
			{
				var direction = Vector2.Normalize(playerPos);
				Position += direction * Speed * Globals.TotalSeconds;
			}
		}


	}
}
