using System;
using KingdomEngine.Model;

namespace KingdomEngine
{
    public class CostCalculator : ICostCalculator
    {        
        private readonly CostCalculatorSettings settings;
        
        public CostCalculator(CostCalculatorSettings settings)
        {
            this.settings = settings;
        }

        public int FarmCost { get; set; }
        public int MarketplaceCost { get; set; }
        public int KnightCost { get; set; }

        public void InflateCosts()
        {
            FarmCost = FarmCost * settings.InflationRate;
            MarketplaceCost = MarketplaceCost * settings.InflationRate;
            KnightCost = KnightCost * settings.InflationRate;
        }
    }
}
