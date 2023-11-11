using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Helpers;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
	public class BloodManager
	{
		private List<BloodEffect> _bloodEffects;

		public BloodManager()
		{
			_bloodEffects = new List<BloodEffect>();
		}

		public void SpawnBlood(Vector2 position, int duration = 300)
		{
			BloodEffect bloodEffect = new BloodEffect(position);
			bloodEffect.Duration = duration;
			_bloodEffects.Add(bloodEffect);
		}

		public void Update()
		{
			foreach (BloodEffect bloodEffect in _bloodEffects.ToList())
			{
				bloodEffect.Update();
				bloodEffect.CurrentTime += (int)(Globals.TotalSeconds * 300);

				if (bloodEffect.CurrentTime >= bloodEffect.Duration)
				{
					bloodEffect.Stop();
					_bloodEffects.Remove(bloodEffect);
				}
			}
		}

		public void Draw()
		{
			foreach (BloodEffect bloodEffect in _bloodEffects)
			{
				bloodEffect.Draw();
			}
		}
	}
}
