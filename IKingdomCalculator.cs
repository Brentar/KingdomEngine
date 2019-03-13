using KingdomEngine.Model;

namespace KingdomEngine
{
    public interface IKingdomCalculator
    {
        int GetFarmCost();
        TurnResults GetTurnResults(EndTurnPackage endTurnPackage);
        int GetKnightCost();
        int GetMarketplaceCost();
        int Turn { get; set; }
    }
}
