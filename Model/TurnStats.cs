using DesktopKingdom.Model;

namespace KingdomEngine.Model
{
    public struct TurnStats
    {
        public int FoodProduced { get; set; }
        public int FoodConsumed { get; set; }
        public int GoldFromTaxes { get; set; }
        public int PeasantsLost { get; set; }
        public int PeasantsGained { get; set; }
        public int MarketPlaceUpkeep { get; set; }
        public int FarmUpkeep { get; set; }
        public RaidResults RaidResults { get; set; }
        public bool Raided { get; set; }
    }
}
