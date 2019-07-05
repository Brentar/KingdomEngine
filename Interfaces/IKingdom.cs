namespace KingdomEngine.Interfaces
{
    public interface IKingdom
    {
        int FarmCount { get; }
        int FarmCost { get; }
        int PeasantCount { get; }
        int ArcherCount { get; }
        int KnightCount { get; }
        int MarketplaceCount { get; }
        int Gold { get; }
        void BuyFarm();
        void EndTurn();
        int GetFarmCost();
    }
}
