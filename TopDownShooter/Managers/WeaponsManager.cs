using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TopDownShooter.Helpers;
using TopDownShooter.Models;
using TopDownShooter.Models.Base;
using TopDownShooter.Models.Weapons;

namespace TopDownShooter.Managers
{
	public static class WeaponsManager
	{
		private static Dictionary<int, Weapon> Arsenal { get; set; }

		public static void Init()
		{
			Arsenal = new Dictionary<int, Weapon>()
			{
				{ 1, new Pistol(Globals.Content.Load<Texture2D>("pistol-bullet")) },
				{ 2, new Shotgun(Globals.Content.Load<Texture2D>("shotgun-bullet")) },
				{ 3, new Rifle(Globals.Content.Load<Texture2D>("rifle-bullet")) },
				{ 4, new Revolver(Globals.Content.Load<Texture2D>("bullet")) }
			};
		}

		public static void SwitchWeapon(Player player, int numberPressed)
		{
			player.CurrentWeapon = Arsenal[numberPressed];
		}

		public static bool WeaponExists(int numberPressed)
		{
			return Arsenal.ContainsKey(numberPressed);
		}


	}
}
