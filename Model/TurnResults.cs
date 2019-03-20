using System;

namespace KingdomEngine.Model
{
    public class TurnResults
    {
        private readonly KingdomSettings settings;
        private const double PercentageConversionNumber = .01;

        public TurnResults(KingdomSettings settings)
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

        private int GetFoodConsumed(int personCount)
        {
            return personCount * settings.FoodConsumptionRate;
        }

        private int GetFoodProduction(int farmCount)
        {
            return farmCount * settings.FoodProductionRate;
        }

        private int GetTaxIncome(int peasantCount, int marketplaceCount)
        {
            int taxIncome = (peasantCount * settings.PeasantIncome * settings.TaxRate);
            int marketplaceMultiplier = Convert.ToInt32(marketplaceCount * .2);
            int additionalIncomeFromMarketplaces = taxIncome * marketplaceMultiplier;

            return taxIncome + additionalIncomeFromMarketplaces;
        }

        public int GetPeasantLeaveCount(int peasantCount)
        {
            int peasantLeaveCount = 0;
            int marketPlaceDiff = 0;
            int farmDiff = 0;

            if (marketPlaceDiff < 0) peasantLeaveCount += Math.Abs(marketPlaceDiff);
            if (farmDiff < 0) peasantLeaveCount += Math.Abs(farmDiff);

            var random = new Random();
            int num = random.Next(1, 10);
            double percentage = num * .01;
            int peasantAttrition = Convert.ToInt32(peasantCount * percentage);

            peasantLeaveCount += peasantAttrition;

            return peasantLeaveCount;
        }

        private int GetPeasantsGained(int farmCount, int peasantCount)
        {
            const int gainMinimum = 1;
            const int noGainResult = 0;
            int totalCapacity = settings.PeasantsPerFarm * farmCount;
            int overage = totalCapacity - peasantCount;

            if (overage < gainMinimum) return noGainResult;
            double peasantsGained = overage * (settings.PeasantGainPercentage * PercentageConversionNumber);
            return Convert.ToInt32(peasantsGained);
        }
    }
}
