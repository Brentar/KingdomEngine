using System;

namespace KingdomEngine.Model
{
    public class EndTurnCalculator
    {
        private readonly EndTurnSettings settings;
        private int farmCount;
        private int peasantCount;
        private int foodCount;

        public EndTurnCalculator(EndTurnSettings settings)
        {
            this.settings = settings;
        }

        public int FoodProduced { get; set; }
        public int FoodConsumed { get; set; }
        public int GoldFromTaxes { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

        public void EndTurn(int peasantCount, int foodCount, int farmCount)
        {
            this.farmCount = farmCount;
            this.peasantCount = peasantCount;
            this.foodCount = foodCount;

            FoodProduced = GetFoodProduced();
            FoodConsumed = GetFoodConsumed();
            PeasantsLost = GetPeasantLeaveCount();
            GoldFromTaxes = GetTaxIncome();
            PeasantsGained = GetPeasantsGained();
        }

        private int GetFoodProduced()
        {
            return farmCount * settings.FoodProductionRate;
        }

        private int GetFoodConsumed()
        {
            return peasantCount * settings.FoodConsumptionRate;
        }

        private int GetTaxIncome()
        {
            int taxIncome = (peasantCount * settings.PeasantIncome * settings.TaxRate);
            int marketplaceMultiplier = Convert.ToInt32(marketplaceCount * .2);
            int additionalIncomeFromMarketplaces = taxIncome * marketplaceMultiplier;

            return taxIncome + additionalIncomeFromMarketplaces;
        }

        private bool AllPeasantsFed()
        {
            return settings.FoodConsumptionRate * peasantCount < foodCount;
        }

        public int GetPeasantLeaveCount()
        {
            if (AllPeasantsFed())
                return 0;

            return peasantCount * new Random().Next(1, peasantCount / 10);
        }

        private int GetPeasantsGained()
        {
            if (!AllPeasantsFed())
                return 0;

            return peasantCount + (peasantCount / 10);
        }
    }
}
