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

        private RaidResults GetRaidResults(int turn, int knightCount, int peasantCount)
        {
            int knightsLost = turn;
            int peasantsLost = 0;
            int foodLost = 0;
            int farmsLost = 0;

            if (knightsLost > knightCount)
                knightsLost = knightCount;

            if (knightCount < turn)
            {
                peasantsLost = turn * 2;
                foodLost = 0;
                farmsLost = turn * 2;
            }

            return new RaidResults
            {
                KnightsLost = knightCount < turn ? knightCount : turn,
                FarmsDestroyed = knightCount < turn ? turn * 2 : 0
            };
        }
    }
}