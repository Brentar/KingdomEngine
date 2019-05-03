using System;

namespace KingdomEngine
{
    public class Treasury : ITreasury
    {
        private readonly ICostCalculator calculator;
        public int Gold { get; private set; }

        public Treasury(ICostCalculator calculator)
        {
            this.calculator = calculator;
        }

        public int GetFarmCost() => calculator.FarmCost;

        public int GetMarketplaceCost() => calculator.MarketplaceCost;

        public int GetKnightCost() => calculator.KnightCost;

        public void AddGold(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Gold += amount;
        }

        public void BuyFarm()
        {
            SpendGold(calculator.FarmCost);
        }

        public void BuyMarketplace()
        {
            SpendGold(calculator.MarketplaceCost);
        }

        public void TrainKnight()
        {
            SpendGold(calculator.KnightCost);
        }

        private void SpendGold(int cost)
        {
            if (Gold < cost)            
                throw new NotEnoughGoldException();            

            Gold -= cost;
        }
    }
}
