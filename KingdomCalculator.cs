using System;
using KingdomEngine.Model;

namespace KingdomEngine
{
    public class CostCalculator : IKingdomCalculator
    {
        private const int StartingTurn = 1;
        private readonly KingdomSettings settings;
        private const double PercentageConversionNumber = .01;

        public CostCalculator(KingdomSettings settings)
        {
            this.settings = settings;
            Turn = StartingTurn;
        }

        public int Turn { get; set; }

        public TurnResults GetTurnResults (EndTurnPackage endTurnPackage)
        {
            int foodProduced = GetFoodProduction(endTurnPackage.FarmCount);
            int foodConsumed = GetFoodConsumed(endTurnPackage.ArcherCount + endTurnPackage.KnightCount + endTurnPackage.PeasantCount);
            int goldFromTaxes = GetTaxIncome(endTurnPackage.PeasantCount, endTurnPackage.MarketplaceCount);
            int peasantsLost = GetPeasantLeaveCount(endTurnPackage.PeasantCount);
            int peasantsGained = GetPeasantsGained(endTurnPackage.FarmCount, endTurnPackage.PeasantCount);

            return new TurnResults
            {
                FoodConsumed = foodConsumed,
                FoodProduced = foodProduced,
                PeasantsGained = peasantsGained,
                PeasantsLost = peasantsLost,
                GoldFromTaxes = goldFromTaxes,
            };
        }

        private int GetInflatedCost(int baseCost)
        {
            double cost = baseCost;

            for (int i = StartingTurn; i < Turn; i++)
            {
                cost += (cost * settings.InflationRate);
            }

            return Convert.ToInt32(cost);
        }

        public int GetFarmCost()
        {
            int cost = GetInflatedCost(settings.BaseFarmCost);
            return cost;
        }

        public int GetKnightCost()
        {
            int cost = GetInflatedCost(settings.BaseKnightCost);
            return cost;
        }

        public int GetMarketplaceCost()
        {
            int cost = Convert.ToInt32(GetInflatedCost(settings.BaseMarketplaceCost));
            return cost;
        }

        private int GetFoodConsumed(int personCount)
        {
            return personCount * settings.FoodConsumptionRate;
        }

        private int GetFoodProduction(int farmCount)
        {
            return farmCount * this.settings.FoodProductionRate;
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
    }
}
