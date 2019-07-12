namespace KingdomEngine.Model
{
    public class EndTurnSettings
    {
        public EndTurnSettings()
        {
        }

        public EndTurnSettings(int foodProductionRate, int foodConsumptionRate, int peasantIncome, int peasantsPerFarm,
            int taxRate, double peasantGainRate, double peasantLossRate, double randomizationMultiplier, int availablePeasants)
        {
            FoodProductionRate = foodProductionRate;
            FoodConsumptionRate = foodConsumptionRate;
            PeasantIncome = peasantIncome;
            PeasantsPerFarm = peasantsPerFarm;
            TaxRate = taxRate;
            PeasantGainRate = peasantGainRate;
            PeasantLossRate = peasantLossRate;
            RandomizationMultiplier = randomizationMultiplier;
            AvailablePeasants = availablePeasants;
        }

        public int FoodProductionRate { get; set; }
        public int FoodConsumptionRate { get; set; }
        public int PeasantIncome { get; set; }
        public int PeasantsPerFarm { get; set; }
        public int TaxRate { get; set; }
        public double PeasantGainRate { get; set; }
        public double PeasantLossRate { get; set; }
        public double RandomizationMultiplier { get; set; }
        public int AvailablePeasants { get; set; }
    }
}
