using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models
{
	public class ZombieSpeedy : Zombie
	{
		public ZombieSpeedy(Texture2D texture, Vector2 position) : base(texture, position)
		{
			Speed = 500;
			HP = 1;
		}
	}
}
