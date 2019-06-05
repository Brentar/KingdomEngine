namespace KingdomEngine.Interfaces
{
    public interface IEconomy
    {
        int FarmCost { get; }
        int MarketplaceCost { get; }
        int KnightCost { get; }
        int ArcherCost { get; }
        int InflationRate { get; set; }
        void InflateCosts();
    }
}
