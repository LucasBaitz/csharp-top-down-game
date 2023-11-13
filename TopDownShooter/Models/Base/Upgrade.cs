using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter.Models.Base
{
	public class Upgrade
	{
        public int AmmoCapacity { get; set; }
		public int ProjectileSpeed { get; set; }
		public int ReloadSpeed { get; set; }
        public int ProjectileLifeSpan { get; set; }

		public void ApplyUpgrade(Weapon weapon)
		{
			
		}
    }
}
