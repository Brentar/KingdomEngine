using DesktopKingdom.Model;
using System;
using KingdomEngine;

namespace DesktopKingdom
{
    public class KingdomCalculator : IKingdomCalculator
    {
        private readonly KingdomSettings settings;

        public KingdomCalculator(KingdomSettings settings)
        {
            this.settings = settings;
        }

        private double GetInflatedCost(int baseCost, int turn)
        {
            double cost = baseCost;

            for (int i = 2; i < turn; i++)
            {
                cost += (cost * this.settings.InflationRate);
            }

            return cost;
        }

        public int GetFarmCost(int turn)
        {
            int cost = Convert.ToInt32(GetInflatedCost(this.settings.BaseFarmCost, turn));
            return cost;
        }

        public int GetKnightCost()
        {
            //int cost = Convert.ToInt32(GetInflatedCost(this.settings.BaseKnightCost));
            return 60;//cost;
        }

        public int GetFoodConsumed(int personCount)
        {
            return (personCount) * this.settings.FoodConsumptionRate;
        }

        public int GetFoodProduction(int farmCount)
        {
            return farmCount * this.settings.FoodProductionRate;
        }

        public int GetTaxIncome(int peasantCount, int marketplaceCount)
        {
            int taxIncome = (int)(peasantCount * this.settings.PeasantIncome * this.settings.TaxRate);

            int marketplaceMultiplier = Convert.ToInt32(marketplaceCount * .2);

            int additionalIncomeFromMarketplaces = taxIncome * marketplaceMultiplier;

            return taxIncome + additionalIncomeFromMarketplaces;
        }

        public int GetMarketplaceCost(int turn)
        {
            int cost = Convert.ToInt32(GetInflatedCost(this.settings.BaseMarketplaceCost, turn));
            return cost;
        }
    }
}
