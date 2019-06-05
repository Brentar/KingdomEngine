namespace KingdomEngine.Model
{
    public class EconomySettings
    {
        public EconomySettings()
        {
        }

        public EconomySettings(
            int inflationRate,
            int baseFarmCost,
            int baseKnightCost,
            int baseMarketplaceCost,
            int baseArcherCost)
        {
            InflationRate = inflationRate;
            BaseFarmCost = baseFarmCost;
            BaseKnightCost = baseKnightCost;
            BaseMarketplaceCost = baseMarketplaceCost;
            BaseArcherCost = baseArcherCost;
        }

        public int InflationRate { get; set; }
        public int BaseFarmCost { get; set; }
        public int BaseKnightCost { get; set; }
        public int BaseMarketplaceCost { get; set; }
        public int BaseArcherCost { get; set; }
    }
}
