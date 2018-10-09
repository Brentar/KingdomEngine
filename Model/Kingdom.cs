using System;
using System.Linq;

namespace KingdomEngine.Model
{
    public class Kingdom : IKingdom
    {
        private readonly IKingdomCalculator calculator;

        public Kingdom(IKingdomCalculator calculator)
        {
            this.calculator = calculator;
        }

        public int PeasantCount { get; set; }
        public int MerchantCount { get; set; }
        public int Gold { get; set; }
        public int Turn { get; set; }
        public int KnightCount { get; set; }
        public int ArcherCount { get; set; }
        public int Food { get; set; }
        public int Towns { get; set; }
        public int MarketplaceCount { get; set; }
        public int FarmCount { get; set; }
        public double TaxRate { get; set; }
        public int Lands { get { return FarmCount + MarketplaceCount; }  }
        public int HappinessLevel { get; set; }                
        public int BaseFarmCost { get; set; }
        public int RaidChance { get; set; }

        public void BuyFarm()
        {
            int cost = calculator.GetFarmCost(Turn);
            if (Gold < cost) return;                        
            Gold -= cost;
            FarmCount++;
        }

        public TurnStats EndTurn()
        {
            int foodProduced = this.calculator.GetFoodProduction(FarmCount);
            int foodConsumed = this.calculator.GetFoodConsumed(ArcherCount + KnightCount + PeasantCount);
            int goldFromTaxes = this.calculator.GetTaxIncome(PeasantCount, MarketplaceCount);
            int peasantsLost = GetPeasantLeaveCount();
            int peasantsGained = GetPeasantJoinCount();
            bool raided = Raided();
            RaidResults raidResults = raided ? GetRaidResults() : new RaidResults();

            var turnStats = new TurnStats
            {
                FoodConsumed = foodConsumed,
                FoodProduced = foodProduced,
                PeasantsGained = peasantsGained,
                PeasantsLost = peasantsLost,
                GoldFromTaxes = goldFromTaxes,
                Raided = raided,
                RaidResults = raidResults
            };

            this.PeasantCount += peasantsGained;
            this.PeasantCount -= peasantsLost;

            if (raided)
            {
                this.PeasantCount -= raidResults.PeasantsKilled;
                this.KnightCount -= raidResults.KnightsLost;
                this.FarmCount -= raidResults.FarmsDestroyed;
            }

            ProduceFood();
            ConsumeFood();

            SetRaidChance();
            this.Gold += goldFromTaxes;
            this.Turn++;


            return turnStats;
        }

        private void ProduceFood()
        {
            int foodProduced = this.calculator.GetFoodProduction(FarmCount);
            this.Food += foodProduced;
        }

        private void ConsumeFood()
        {
            int foodConsumed = this.calculator.GetFoodConsumed(ArcherCount + KnightCount + PeasantCount);
            this.Food -= foodConsumed;
        }

        private int GetPeasantJoinCount()
        {
            int incomingPeasants = 0;
            int marketplaceDiff = 0;
            int farmDiff = 0;

            if (farmDiff > 0) incomingPeasants += farmDiff;
            if (marketplaceDiff > 0) incomingPeasants += marketplaceDiff;

            return incomingPeasants;
        }

        private int GetPeasantLeaveCount()
        {
            int peasantLeaveCount = 0;
            int marketPlaceDiff = 0;
            int farmDiff = 0;

            if (marketPlaceDiff < 0) peasantLeaveCount += Math.Abs(marketPlaceDiff);
            if (farmDiff < 0) peasantLeaveCount += Math.Abs(farmDiff);

            var random = new Random();
            int num = random.Next(1, 10);
            double percentage = num * .01;
            int peasantAttrition = Convert.ToInt32(this.PeasantCount * percentage);

            peasantLeaveCount += peasantAttrition;

            return peasantLeaveCount;
        }



        private int GetFoodSurplus()
        {
            int requiredFood = this.calculator.GetFoodProduction(FarmCount);
            int foodProduced = this.calculator.GetFoodProduction(this.FarmCount);
            bool foodSurplusExists = requiredFood < foodProduced;

            if (foodSurplusExists)
            {
                int overage = foodProduced - requiredFood;
                double percentOverage = overage / (float)requiredFood;
            }

            // todo: finish
            return 0;
        }

        private void SetRaidChance()
        {
            RaidChance = new Random().Next(1, 40);
        }

        private bool Raided()
        {
            var rnd = new Random();
            int[] nums = new int[RaidChance];
            for (int i = 0; i < RaidChance; i++)
            {
                nums[i] = rnd.Next(1, 101);
            }

            int hit = rnd.Next(1, 101);
            return nums.Contains(hit);
        }

        private RaidResults GetRaidResults()
        {
            int enemyCount = Turn*new Random().Next(1, 10);
            bool win = KnightCount > enemyCount;

            var raidResults = new RaidResults
            {
                Win = win,
                KnightsLost = Convert.ToInt32(enemyCount/2),
                PeasantsKilled = win ? 0: Convert.ToInt32(enemyCount / 3),
                FarmsDestroyed = win ? 0: Convert.ToInt32(this.FarmCount * .1)
            };

            return raidResults;            
        }
    }
}
