namespace KingdomEngine.Model
{
    public class EndTurnSettings
    {
        public int FoodProductionRate { get; set; }
        public int FoodConsumptionRate { get; set; }
        public int PeasantIncome { get; set; }
        public int PeasantsPerFarm { get; set; }
        public int TaxRate { get; set; }
        public int PeasantGainPercentage { get; set; }
        public const double RandomizationMultiplier = .1;
    }
}
