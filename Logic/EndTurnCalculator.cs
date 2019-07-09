using System;
using KingdomEngine.Interfaces;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class EndTurnCalculator : IEndTurnCalculator
    {
        private readonly EndTurnSettings settings;
        private EndTurnPackage endTurnPackage;
        private readonly IRandomizer randomizer;

        public EndTurnCalculator(EndTurnSettings settings, IRandomizer randomizer)
        {
            this.settings = settings;
            this.randomizer = randomizer;
        }

        public int FoodProduced { get; private set; }
        public int FoodConsumed { get; set; }
        public int TaxIncome { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }

        public void EndTurn(EndTurnPackage package)
        {
            endTurnPackage = package;

            SetFoodProduced();
            SetFoodConsumed();
            SetPeasantsLost();
            SetTaxIncome();
            SetPeasantsGained();
        }

        private void SetFoodProduced()
        {
            FoodProduced = randomizer.GetRandomizedAmount(endTurnPackage.FarmCount * settings.FoodProductionRate);
        }

        private void SetFoodConsumed()
        {
            int foodNeeded = GetFoodNeeded();
            int totalFood = endTurnPackage.FoodCount + FoodProduced;
            FoodConsumed = randomizer.GetRandomizedAmount(foodNeeded);

            if (FoodConsumed > totalFood)
                FoodConsumed = totalFood;
        }

        private int GetFoodNeeded()
        {
            return endTurnPackage.PeasantCount * settings.FoodConsumptionRate;
        }

        private void SetTaxIncome()
        {
            double taxMultiplier = settings.TaxRate * .01;
            int peasantIncome = settings.PeasantIncome * endTurnPackage.PeasantCount;
            TaxIncome = Convert.ToInt32(peasantIncome * taxMultiplier);
        }

        private bool AllPeasantsFed()
        {
            int foodNeeded = GetFoodNeeded();
            int totalFood = FoodProduced + endTurnPackage.FoodCount;
            
            return totalFood >= foodNeeded;
        }

        private void SetPeasantsLost()
        {
            int peasantsLost =
                AllPeasantsFed()
                    ? 0
                    : randomizer.GetRandomizedAmount(
                        Convert.ToInt32(endTurnPackage.PeasantCount * settings.PeasantLossRate));

            int totalPeasants = endTurnPackage.PeasantCount + PeasantsGained;

            if (peasantsLost > totalPeasants)
                peasantsLost = totalPeasants;

            PeasantsLost = peasantsLost;
        }

        private void SetPeasantsGained()
        {
            PeasantsGained =
                !AllPeasantsFed()
                    ? 0
                    : randomizer.GetRandomizedAmount(Convert.ToInt32(endTurnPackage.PeasantCount * settings.PeasantGainRate));
        }
    }
}
