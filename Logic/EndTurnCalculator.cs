using System;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class EndTurnCalculator : IEndTurnCalculator
    {
        private readonly EndTurnSettings settings;
        private const double PeasantLossRate = .1;
        private const double PeasantGainRate = .1;

        public EndTurnCalculator(EndTurnSettings settings)
        {
            this.settings = settings;
        }

        private EndTurnPackage EndTurnPackage { get; set; }
        public int FoodProduced { get; private set; }
        public int FoodConsumed { get; set; }
        public int TaxIncome { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

        public void EndTurn(EndTurnPackage endTurnPackage)
        {
            EndTurnPackage = endTurnPackage;

            SetFoodProduced();
            SetFoodConsumed();
            SetPeasantsLost();
            SetTaxIncome();
            SetPeasantsGained();
        }

        private void SetFoodProduced()
        {
            FoodProduced = EndTurnPackage.FarmCount * settings.FoodProductionRate;
        }

        private void SetFoodConsumed()
        {
            FoodConsumed = EndTurnPackage.PeasantCount * settings.FoodConsumptionRate;
        }

        private void SetTaxIncome()
        {
            TaxIncome = EndTurnPackage.PeasantCount * settings.TaxRate;
        }

        public void SetPeasantsLost()
        {
            PeasantsLost =
                AllPeasantsFed()
                    ? 0
                    : Convert.ToInt32(EndTurnPackage.PeasantCount * PeasantLossRate);
        }

        private bool AllPeasantsFed()
        {
            return settings.FoodConsumptionRate * EndTurnPackage.PeasantCount < EndTurnPackage.FoodCount;
        }

        private void SetPeasantsGained()
        {
            PeasantsGained =
                !AllPeasantsFed()
                    ? 0
                    : Convert.ToInt32(EndTurnPackage.PeasantCount * PeasantGainRate);
        }
    }
}
