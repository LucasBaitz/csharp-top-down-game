using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Helpers;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
	public static class PlayerSpriteManager
	{
		private static Dictionary<int, Texture2D> _playerSprites;
        public static Texture2D CurrentSprite { get; set; }

		public static void Init()
		{
			_playerSprites = new Dictionary<int, Texture2D>()
			{
				{ 1, Globals.Content.Load<Texture2D>("player") },
				{ 2, Globals.Content.Load<Texture2D>("player-shotgun") },
				{ 3, Globals.Content.Load<Texture2D>("player-rifle") },
				{ 4, Globals.Content.Load<Texture2D>("player-revolver") }
			};

			CurrentSprite = _playerSprites[1];
		}

		public static void Update(int numberPressed)
		{
			CurrentSprite = _playerSprites[numberPressed];
		}

		public static bool SpriteExists(int numberPressed)
		{
			return _playerSprites.ContainsKey(numberPressed);
		}
	}
}
