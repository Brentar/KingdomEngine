namespace KingdomEngine.Model
{
    public class CostCalculatorSettings
    {
        public CostCalculatorSettings(int inflationRate, int baseFarmCost, int baseKnightCost, int baseMarketplaceCost)
        {
            InflationRate = inflationRate;
            BaseFarmCost = baseFarmCost;
            BaseKnightCost = baseKnightCost;
            BaseMarketplaceCost = baseMarketplaceCost;
        }

        public int InflationRate { get; set; }
        public int BaseFarmCost { get; set; }
        public int BaseKnightCost { get; set; }
        public int BaseMarketplaceCost { get; set; }
    }
}
