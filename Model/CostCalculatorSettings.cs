namespace KingdomEngine.Model
{
    public class CostCalculatorSettings
    {
        public CostCalculatorSettings()
        {
        }

        public CostCalculatorSettings(
            uint inflationRate,
            uint baseFarmCost,
            uint baseKnightCost,
            uint baseMarketplaceCost,
            uint baseArcherCost)
        {
            InflationRate = inflationRate;
            BaseFarmCost = baseFarmCost;
            BaseKnightCost = baseKnightCost;
            BaseMarketplaceCost = baseMarketplaceCost;
            BaseArcherCost = baseArcherCost;
        }

        public uint InflationRate { get; set; }
        public uint BaseFarmCost { get; set; }
        public uint BaseKnightCost { get; set; }
        public uint BaseMarketplaceCost { get; set; }
        public uint BaseArcherCost { get; set; }
    }
}
