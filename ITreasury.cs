namespace KingdomEngine
{
    public interface ITreasury
    {
        int Gold { get; }
        void BuyFarm();
        void BuyMarketplace();
        void TrainKnight();
        void AddGold(int amount);
        int GetFarmCost();
        int GetMarketplaceCost();
        int GetKnightCost();
    }
}
