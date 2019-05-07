namespace KingdomEngine
{
    public interface ITreasury
    {
        uint Gold { get; }
        void BuyFarm();
        void BuyMarketplace();
        void TrainKnight();
        void AddGold(uint amount);
        uint GetFarmCost();
        uint GetMarketplaceCost();
        uint GetKnightCost();
        void InflateCosts();
        void TrainArcher();
    }
}
