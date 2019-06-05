using System;
using KingdomEngine.Interfaces;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class Economy : IEconomy
    {        
        private readonly EconomySettings settings;
        
        public Economy(EconomySettings settings)
        {
            this.settings = settings;
            SetInitialValues();
        }

        public int FarmCost { get; set; }
        public int MarketplaceCost { get; set; }
        public int KnightCost { get; set; }
        public int ArcherCost { get; set; }

        public int InflationRate
        {
            get { return settings.InflationRate; }
            set { settings.InflationRate = value; }
        }

        public void InflateCosts()
        {
            double inflation = settings.InflationRate * .01;

            FarmCost += Convert.ToInt32(FarmCost * inflation);
            MarketplaceCost += Convert.ToInt32(MarketplaceCost * inflation);
            KnightCost += Convert.ToInt32(KnightCost * inflation);
            ArcherCost += Convert.ToInt32(ArcherCost * inflation);
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
