using KingdomEngine.Model;

namespace KingdomEngine
{
    public interface IBuyer
    {
        void BuyFarm();
        void BuyMarketplace();
    }
    public class Buyer
    {
        private IKingdomCalculator calculator;
        private Kingdom kingdom;

        public Buyer(IKingdomCalculator calculator, Kingdom kingdom)
        {
            this.calculator = calculator;
            this.kingdom = kingdom;
        }
        public void BuyFarm()
        {
            int farmCost = this.calculator.GetFarmCost(this.kingdom.Turn);

        }
    }
}
