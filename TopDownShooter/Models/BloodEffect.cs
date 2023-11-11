using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Helpers;

namespace TopDownShooter.Models
{
	public class BloodEffect
	{
		private static Texture2D _texture;
		private Vector2 _position;
		private readonly Animation _anim;
        public bool IsActive { get; set; }
        public int Duration { get; set; }
		public int CurrentTime { get; set; }

        public BloodEffect(Vector2 pos)
		{
			_texture ??= Globals.Content.Load<Texture2D>("blood");
			_anim = new(_texture, 6, 1, 0.1f);
			_position = pos;
		}

		public void Stop()
		{
			_anim.Stop();
		}

		public void Update()
		{
			_anim.Update();
		}

		public void Draw()
		{
			_anim.Draw(_position);
		}
	}
}
