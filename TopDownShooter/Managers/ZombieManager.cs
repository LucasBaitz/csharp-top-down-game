using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TopDownShooter.Helpers;
using TopDownShooter.Models;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Managers
{
	public class ZombieManager
	{
		private static Texture2D _texture;
		private static Texture2D _bossTexture;
		private static Texture2D _speedTexture;
		private static int _maxZombie;
		public static List<Zombie> Zombies { get; } = new List<Zombie>();
		private static float _spawnCooldown;
		private static float _spawnTimer;
		private static Random _random;
		private static int _padding;


		public static void Init()
		{
			_texture = Globals.Content.Load<Texture2D>("zombie");
			_bossTexture = Globals.Content.Load<Texture2D>("tank-zombie");
			_speedTexture = Globals.Content.Load<Texture2D>("zombie-speed");
			_spawnCooldown = 1.2f;
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
			return _random.Next(130, 170);
		}

		public static void AddZombie()
		{
			Zombies.Add(new Zombie(_texture, RandomPosition(), RandomSpeed()));
		}

		public static void AddZombieTank()
		{
			Zombies.Add(new ZombieTank(_bossTexture, RandomPosition()));
		}

		public static void AddZombieSpeedy()
		{
			Zombies.Add(new ZombieSpeedy(_speedTexture, RandomPosition()));
		}

		public static void Update(Player player)
		{
			_maxZombie = RoundsManager.KillsToNextRound - player.KillCount;
			ZombieSpawner();

			foreach (Zombie zomb in Zombies)
			{
				zomb.Update(player);
			}

			player.KillCount += Zombies.Where(z => z.IsDead).ToList().Count;
			Zombies.RemoveAll(z => z.IsDead);
		}

		private static void ZombieSpawner()
		{
			if (Zombies.Count < _maxZombie)
			{
				_spawnTimer -= Globals.TotalSeconds;
				if (_spawnTimer <= 0)
				{
					_spawnTimer += _spawnCooldown;
					double spawnChance = _random.NextDouble();
					if (spawnChance < 0.1)
					{
						double zombieTypeChance = _random.NextDouble();
						if (zombieTypeChance < 0.5)
						{
							AddZombieTank();
						}
						else
						{
							AddZombieSpeedy();
						}
					}
					else
					{
						AddZombie();
					}
				}
			}
		}


		public static void Draw()
		{
			foreach (Zombie zomb in Zombies)
			{
				zomb.Draw();
			}
		}

		public static void ResetWave()
		{
			Zombies.Clear();
			_spawnCooldown -= RoundsManager.DifficultyMultiplier;	
		}

		public static void Reset()
		{
			Zombies.Clear();
			_spawnCooldown = 1.2f;
			_spawnTimer = _spawnCooldown;
		}
	}
}
