using System;
using KingdomEngine.Interfaces;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class EndTurnCalculator : IEndTurnCalculator
    {
        private readonly EndTurnSettings settings;
        private const double PeasantLossRate = .1;
        private const double PeasantGainRate = .1;
        private EndTurnPackage endTurnPackage;
        private int availablePeasants = 5000;
        private const double RandomizationMultiplier = .1;
        private readonly Random random;


        public EndTurnCalculator(EndTurnSettings settings, IRandomizer randomizer)
        {
            random = new Random();
            this.settings = settings;
            //this.randomizer = randomizer;
        }

        public int FoodProduced { get; private set; }
        public int FoodConsumed { get; set; }
        public int TaxIncome { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

        public void EndTurn(EndTurnPackage package)
        {
            this.endTurnPackage = package;

            SetFoodProduced();
            SetFoodConsumed();
            SetPeasantsLost();
            SetTaxIncome();
            SetPeasantsGained();
        }

        private void SetFoodProduced()
        {
            FoodProduced =
                GetRandomizedAmount(
                    endTurnPackage.FarmCount * settings.FoodProductionRate);
        }

        private void SetFoodConsumed()
        {
            FoodConsumed = GetRandomizedAmount(endTurnPackage.PeasantCount * settings.FoodConsumptionRate);
        }

        private void SetTaxIncome()
        {
            double taxMultiplier = settings.TaxRate * .01;
            int peasantIncome = settings.PeasantIncome * endTurnPackage.PeasantCount;
            TaxIncome = Convert.ToInt32(peasantIncome * taxMultiplier);
        }

        private void SetPeasantsLost()
        {
            PeasantsLost =
                AllPeasantsFed()
                    ? 0
                    : Convert.ToInt32(availablePeasants * PeasantLossRate);
        }

        private bool AllPeasantsFed()
        {
            return settings.FoodConsumptionRate * endTurnPackage.PeasantCount < endTurnPackage.FoodCount;
        }

        private void SetPeasantsGained()
        {
            PeasantsGained =
                !AllPeasantsFed()
                    ? 0
                    : Convert.ToInt32(endTurnPackage.PeasantCount * PeasantGainRate);
        }

        private int GetRandomizedAmount(int amount)
        {
            int plusOrMinusAmount = Convert.ToInt32(amount * settings.RandomizationMultiplier);
            int minRange = amount - plusOrMinusAmount;
            int maxRange = amount + plusOrMinusAmount;
            return random.Next(minRange, maxRange);
        }
    }
}
