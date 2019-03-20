using System;
using KingdomEngine.Model;

namespace KingdomEngine
{
    public class CostCalculator : ICostCalculator
    {
        private const int StartingInflationIndex = 1;
        private readonly KingdomSettings settings;
        private int inflationIndex;

        public CostCalculator(KingdomSettings settings)
        {
            this.settings = settings;
        }

        public void IncrementInflation()
        {
            inflationIndex++;
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

        private int GetInflatedCost(int baseCost)
        {
            double cost = baseCost;

            for (int i = StartingInflationIndex; i < inflationIndex; i++)
            {
                cost += cost * settings.InflationRate;
            }

            return Convert.ToInt32(cost);
        }
    }
}
