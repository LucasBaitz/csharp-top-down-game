using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
	public static class RoundsManager
	{
		public static int RoundCounter { get; set; } = 1;
		public static int KillsToNextRound { get; set; } = 10;
		private static int _killIncrease = 20;
		public static float DifficultyMultiplier { get; set; } = 0.050f;

		public static void Init()
		{

		}

		public static void Update(Player player)
		{
			if (PlayerReachedGoal(player))
			{
				SetNextRound();
				ZombieManager.ResetWave();
			}
		}

		public static void SetNextRound()
		{
			RoundCounter++;
			if (RoundCounter % 5 == 0)
			{
				_killIncrease *= 2;
			}
			KillsToNextRound += _killIncrease;
		}

		public static bool PlayerReachedGoal(Player player)
		{
			return player.KillCount >= KillsToNextRound;
		}

		public static void Reset()
		{
			KillsToNextRound = 10;
			RoundCounter = 1;
		}

		public static bool IsBossRound()
		{
			return RoundCounter % 2 == 0;
		}
    }
}
