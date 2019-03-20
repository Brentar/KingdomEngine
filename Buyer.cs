using System;

namespace KingdomEngine
{
    public class Buyer : IBuyer
    {
        private readonly ICostCalculator calculator;
        public int Gold { get; private set; }

        public Buyer(ICostCalculator calculator, int initialGold)
        {
            this.calculator = calculator;
            Gold = initialGold;
        }

        public void AddGold(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Gold += amount;
        }

        public void BuyFarm()
        {
            int cost = calculator.GetFarmCost();
            SpendGold(cost);
        }

        public void BuyMarketplace()
        {
            int cost = calculator.GetMarketplaceCost();
            SpendGold(cost);
        }

        public void TrainKnight()
        {
            int cost = calculator.GetKnightCost();
            SpendGold(cost);
        }

        public bool TryTrainKnight()
        {
            int cost = calculator.GetKnightCost();
            bool goldSpent = TrySpendGold(cost);
            return goldSpent;
        }

        private bool TrySpendGold(int cost)
        {
            if (Gold < cost)
            {
                return false;
            }

            Gold -= cost;
            return true;
        }

        private void SpendGold(int cost)
        {
            if (Gold < cost)
            {
                throw new NotEnoughGoldException();
            }

            Gold -= cost;
        }
    }
}
