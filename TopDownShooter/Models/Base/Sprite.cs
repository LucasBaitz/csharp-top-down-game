﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Helpers;

namespace TopDownShooter.Models.Base
{
	public class Sprite
	{
		protected Texture2D texture;
		protected readonly Vector2 origin;
		public Vector2 Position { get; set; }
		public int Speed { get; set; } = 300;
		public float Rotation { get; set; }
		public float Scale { get; set; }
		public Color Color { get; set; }

		public Sprite(Texture2D tex, Vector2 pos)
		{
			texture = tex;
			Position = pos;
			origin = new(tex.Width / 2, tex.Height / 2);
			Scale = 1f;
			Color = Color.White;
		}

		public virtual void Draw()
		{
			Globals.SpriteBatch.Draw(texture, Position, null, Color, Rotation, origin, Scale, SpriteEffects.None, 1);
		}
	}
}
