using System;

namespace KingdomEngine.Model
{
    public class TurnResults
    {
        private readonly KingdomSettings settings;
        private const double PercentageConversionNumber = .01;

        public TurnResults(KingdomSettings settings)
        {
            this.settings = settings;
        }

        public int FoodProduced { get; set; }
        public int FoodConsumed { get; set; }
        public int GoldFromTaxes { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }

        private int GetPeasantsGained(int farmCount, int peasantCount)
        {
            const int gainMinimum = 1;
            const int noGainResult = 0;
            int totalCapacity = settings.PeasantsPerFarm * farmCount;
            int overage = totalCapacity - peasantCount;

            if (overage < gainMinimum) return noGainResult;
            double peasantsGained = overage * (settings.PeasantGainPercentage * PercentageConversionNumber);
            return Convert.ToInt32(peasantsGained);
        }
    }
}
