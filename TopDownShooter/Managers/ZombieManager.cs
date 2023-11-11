using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using TopDownShooter.Helpers;
using TopDownShooter.Models;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Managers
{
	public class ZombieManager
	{
		private static Texture2D _texture;
		public static List<Zombie> Zombies { get; } = new List<Zombie>();
		private static float _spawnCooldown;
		private static float _spawnTimer;
		private static Random _random;
		private static int _padding;


		public static void Init()
		{
			_texture = Globals.Content.Load<Texture2D>("zombie");
			_spawnCooldown = 0.7f;
			_spawnTimer = _spawnCooldown;
			_random = new Random();
			_padding = _texture.Width / 2;
		}

		private static Vector2 RandomPosition()
		{
			float w = Globals.Bounds.X;
			float h = Globals.Bounds.Y;
			Vector2 spawnLocation = new Vector2();

			if (_random.NextDouble() < w / (w + h))
			{
				spawnLocation.X = (int)(_random.NextDouble() * w);
				spawnLocation.Y = (int)(_random.NextDouble() < 0.5 ? -_padding : h + _padding);
			}
			else
			{
				spawnLocation.Y = (int)(_random.NextDouble() * h);
				spawnLocation.X = (int)(_random.NextDouble() < 0.5 ? -_padding : w + _padding);
			}

			return spawnLocation;

		}

		private static int RandomSpeed()
		{
			return _random.Next(100, 250);
		}

		public static void AddZombie()
		{
			Zombies.Add(new Zombie(_texture, RandomPosition(), RandomSpeed()));
		}

		public static void Update(Player player)
		{
			_spawnTimer -= Globals.TotalSeconds;
			if (_spawnTimer <= 0)
			{
				_spawnTimer += _spawnCooldown;
				AddZombie();
			}

			foreach (Zombie zomb in Zombies)
			{
				zomb.Update(player);
			}
			Zombies.RemoveAll(z => z.HP <= 0);
		}

		public static void Draw()
		{
			foreach (Zombie zomb in Zombies)
			{
				zomb.Draw();
			}
		}
		public static void Reset()
		{
			Zombies.Clear();
			_spawnTimer = _spawnCooldown;
		}
	}
}
