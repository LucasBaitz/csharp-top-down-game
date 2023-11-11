using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter.Models
{
	public sealed class ProjectileData
	{
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
		public float Rotation { get; set; }
		public float Lifespan { get; set; } = 1;
		public int Speed { get; set; } = 1000;
		public int Damage { get; set; }
	}
}
