using System;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class CostCalculator : ICostCalculator
    {        
        private readonly CostCalculatorSettings settings;
        
        public CostCalculator(CostCalculatorSettings settings)
        {
            this.settings = settings;
            SetInitialValues();
        }

        public uint FarmCost { get; set; }
        public uint MarketplaceCost { get; set; }
        public uint KnightCost { get; set; }
        public uint ArcherCost { get; set; }

        public void InflateCosts()
        {
            const double percentageMultiplier = .01;
            double inflationRate = settings.InflationRate * percentageMultiplier;

            FarmCost += Convert.ToUInt32(FarmCost * inflationRate);
            MarketplaceCost += Convert.ToUInt32(MarketplaceCost * inflationRate);
            KnightCost += Convert.ToUInt32(KnightCost * inflationRate);
            ArcherCost += Convert.ToUInt32(ArcherCost * inflationRate);
        }

        private void SetInitialValues()
        {
            FarmCost = settings.BaseFarmCost;
            MarketplaceCost = settings.BaseMarketplaceCost;
            KnightCost = settings.BaseKnightCost;
            ArcherCost = settings.BaseArcherCost;
        }
    }
}
