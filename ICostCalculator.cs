namespace KingdomEngine
{
    public interface ICostCalculator
    {
        uint FarmCost { get; }
        uint MarketplaceCost { get; }
        uint KnightCost { get; }
        uint ArcherCost { get; }
        void InflateCosts();
    }
}
