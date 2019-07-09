using KingdomEngine.Model;

namespace KingdomEngine.Interfaces
{
    public interface IKingdom
    {
        int FarmCount { get; }
        int FarmCost { get; }
        int ArcherCost { get; }
        int MarketplaceCost { get; }
        int PeasantCount { get; }
        int ArcherCount { get; }
        int KnightCount { get; }
        int MarketplaceCount { get; }
        int FoodCount { get; }
        int Turn { get; }
        int Gold { get; }
        TurnResults GetEndTurnResults();
        void BuyFarm();
        int GetKnightCost();
        void BuyMarketplace();
        void TrainKnight();
        void TrainArcher();
        void EndTurn();
    }
}
