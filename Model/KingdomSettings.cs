namespace DesktopKingdom.Model
{
    public class KingdomSettings
    {
        public KingdomSettings()
        {
            MarketplaceSettings = new LandSettings();
            FarmSettings = new LandSettings();
        }

        public int MerchantCost { get; set; }
        public int BaseFarmCost { get; set; }
        public int BaseKnightCost { get; set; }
        public int BaseMarketplaceCost { get; set; }
        public double FarmMaintenanceCost { get; set; }
        public int FoodProductionRate { get; set; }
        public int FoodConsumptionRate { get; set; }
        public LandSettings MarketplaceSettings { get; set; }
        public LandSettings FarmSettings { get; set; }
        public double InflationRate { get; set; }       
        public int PeasantIncome { get; set; }
        public int TaxRate { get; set; }

        public class LandSettings
        {
            public int PeasantCapacity { get; set; }
            public double MaintenanceCost { get; set; }
        }
    }
}
