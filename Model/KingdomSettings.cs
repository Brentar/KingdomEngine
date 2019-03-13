namespace KingdomEngine.Model
{
    public class KingdomSettings
    {
        public int MerchantCost { get; set; }
        public int BaseFarmCost { get; set; }
        public int BaseKnightCost { get; set; }
        public int BaseMarketplaceCost { get; set; }
        public int FoodProductionRate { get; set; }
        public int FoodConsumptionRate { get; set; }
        public double InflationRate { get; set; }       
        public int PeasantIncome { get; set; }
        public int PeasantsPerFarm { get; set; }
        public int TaxRate { get; set; }
        public int PeasantGainPercentage { get; set; }
    }
}
