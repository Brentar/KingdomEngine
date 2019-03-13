namespace KingdomEngine
{
    public interface IBuyer
    {
        int Gold { get; }
        void BuyFarm();
        void BuyMarketplace();
        void TrainKnight();
        bool TryTrainKnight();
        void AddGold(int amount);
    }
}
