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
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

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

            //FoodProduced = GetRandomizedAmount(endTurnPackage.FarmCount * settings.FoodProductionRate);
        }

        private void SetFoodConsumed()
        {
            FoodConsumed = randomizer.GetRandomizedAmount(endTurnPackage.PeasantCount * settings.FoodConsumptionRate);
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
    }
}
