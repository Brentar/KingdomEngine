namespace KingdomEngine
{
    public interface ICostCalculator
    {
        int FarmCost { get; }
        int MarketplaceCost { get; }
        int KnightCost { get; }
        void InflateCosts();
    }
}
