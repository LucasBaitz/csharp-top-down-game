using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TopDownShooter.Helpers;
using TopDownShooter.Managers;
using TopDownShooter.Models.Base;

namespace TopDownShooter.Models
{
	public class Player : Sprite
	{
		public Weapon CurrentWeapon { get; set; }
		private readonly int _initialHp;
		public int HP { get; set; }
		public int KillCount { get; set; } = 0;
		public bool IsDead { get; private set; } = false;
		public bool TookDamage { get; private set; } = false;
		private float _takeDamageCooldown;
		private float _takeDamageCooldownLeft;
		public Player(Texture2D texture, Vector2 position) : base(texture, position)
		{
			WeaponsManager.SwitchWeapon(this, 1);
			_initialHp = 3;
			HP = _initialHp;
			_takeDamageCooldown = 10f;
			_takeDamageCooldownLeft = 0f;
		}

		private Vector2 GetStartPosition()
		{
			return new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
		}

		public void Reset()
		{
			IsDead = false;
			HP = _initialHp;
			Position = GetStartPosition();
			KillCount = 0;
		}

		private void CheckHit(Zombie z)
		{
			if (_takeDamageCooldownLeft > 0 || TookDamage) return;

			if ((Position - z.Position).Length() < 50)
			{
				HP -= 1;
				TookDamage = true;
				_takeDamageCooldownLeft = _takeDamageCooldown;
			}
		}


		private void TakeDamageCooldownUpdate()
		{
			if (_takeDamageCooldownLeft > 0)
			{
				_takeDamageCooldownLeft -= Globals.TotalSeconds;
			}
			else if (TookDamage)
			{
				TookDamage = false;
			}
		}


		private void CheckDeath(List<Zombie> zombies)
		{
			foreach (var z in zombies)
			{
				TakeDamageCooldownUpdate();
				if (z.HP <= 0) continue;
				CheckHit(z);
				if (HP <= 0)
				{
					IsDead = true;
					break;
				}
			}
		}

		public void Update(List<Zombie> zombies)
		{
			if (InputManager.Direction != Vector2.Zero)
			{
				var direction = Vector2.Normalize(InputManager.Direction);
				Position = new(
					MathHelper.Clamp(Position.X + (direction.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
					MathHelper.Clamp(Position.Y + (direction.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
				);
			}

			var mousePoint = InputManager.MousePosition - Position;
			Rotation = (float)Math.Atan2(mousePoint.Y, mousePoint.X);

			CurrentWeapon.Update();

			if (InputManager.MouseLeftDown)
			{
				CurrentWeapon.Shoot(this);
			}
			if (InputManager.MouseRightGotClicked)
			{
				CurrentWeapon.Reload();
			}
			if (WeaponsManager.WeaponExists(InputManager.LastNumberKeyPressed))
			{
				WeaponsManager.SwitchWeapon(this, InputManager.LastNumberKeyPressed);
				PlayerSpriteManager.Update(InputManager.LastNumberKeyPressed);
				this.texture = PlayerSpriteManager.CurrentSprite;
			}

			CheckDeath(zombies);
		}
	}
}

