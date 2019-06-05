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

        public EndTurnCalculator(EndTurnSettings settings)
        {
            this.settings = settings;
        }

        public int FoodProduced { get; private set; }
        public int FoodConsumed { get; set; }
        public int TaxIncome { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

        public void EndTurn(EndTurnPackage endTurnPackage)
        {
            this.endTurnPackage = endTurnPackage;

            SetFoodProduced();
            SetFoodConsumed();
            SetPeasantsLost();
            SetTaxIncome();
            SetPeasantsGained();
        }

        private void SetFoodProduced()
        {
            FoodProduced = endTurnPackage.FarmCount * settings.FoodProductionRate;
        }

        private void SetFoodConsumed()
        {
            FoodConsumed = endTurnPackage.PeasantCount * settings.FoodConsumptionRate;
        }

        private void SetTaxIncome()
        {
            TaxIncome = endTurnPackage.PeasantCount * settings.TaxRate;
        }

        public void SetPeasantsLost()
        {
            PeasantsLost =
                AllPeasantsFed()
                    ? 0
                    : Convert.ToInt32(endTurnPackage.PeasantCount * PeasantLossRate);
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
