using System;

namespace KingdomEngine.Logic
{
    public class Treasury : ITreasury
    {
        private readonly ICostCalculator calculator;
        public uint Gold { get; private set; }

        public Treasury(ICostCalculator calculator)
        {
            this.calculator = calculator;
        }

        public uint GetFarmCost() => calculator.FarmCost;

        public uint GetMarketplaceCost() => calculator.MarketplaceCost;

        public uint GetKnightCost() => calculator.KnightCost;

        public void InflateCosts() => calculator.InflateCosts();

        public void AddGold(uint amount)
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

        public void TrainArcher()
        {
            SpendGold(calculator.ArcherCost);
        }

        private void SpendGold(uint cost)
        {
            if (Gold < cost)            
                throw new NotEnoughGoldException();            

            Gold -= cost;
        }       
    }
}
