using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using TopDownShooter.Helpers;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models
{
	public class Projectile : Sprite
	{
		public Vector2 Direction { get; set; }
		public float Lifespan { get; set; }
		public int Damage { get; set; }

		public Projectile(Texture2D texture, ProjectileData data) : base(texture, data.Position)
		{
			Speed = data.Speed;
			Rotation = data.Rotation;
			Direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
			Lifespan = data.Lifespan;
			Damage = data.Damage;
		}

		public void Update()
		{
			Position += Direction * Speed * Globals.TotalSeconds;
			Lifespan -= Globals.TotalSeconds;
		}

		public void Destroy()
		{
			Lifespan = 0;
		}
	}
}
