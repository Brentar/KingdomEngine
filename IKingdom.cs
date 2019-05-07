namespace KingdomEngine.Model
{
    public interface IKingdom
    {
        int FarmCount { get; }
        int PeasantCount { get; }
        int ArcherCount { get; }
        int KnightCount { get; }
        int MarketplaceCount { get; }
        void EndTurn();
    }
}
