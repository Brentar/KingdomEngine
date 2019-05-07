using System;
using System.Linq;
using KingdomEngine.Logic;

namespace KingdomEngine.Model
{
    public class RaidHandler
    {
        private Kingdom kingdom;
        private int raidChance;

        public RaidHandler(Kingdom kingdom)
        {
            this.kingdom = kingdom;
        }

        private void SetRaidChance()
        {
            raidChance = new Random().Next(1, 40);
        }

        private bool Raided()
        {
            var rnd = new Random();
            int[] nums = new int[raidChance];
            for (int i = 0; i < raidChance; i++)
            {
                nums[i] = rnd.Next(1, 101);
            }

            int hit = rnd.Next(1, 101);
            return nums.Contains(hit);
        }

        private RaidResults GetRaidResults()
        {
            int enemyCount = kingdom.Turn*new Random().Next(1, 10);
            bool win = kingdom.KnightCount > enemyCount;

            var raidResults = new RaidResults
            {
                Win = win,
                KnightsLost = Convert.ToInt32(enemyCount/2),
                PeasantsKilled = win ? 0: Convert.ToInt32(enemyCount / 3),
                FarmsDestroyed = win ? 0: Convert.ToInt32(kingdom.FarmCount * .1)
            };

            return raidResults;            
        }
    }
}