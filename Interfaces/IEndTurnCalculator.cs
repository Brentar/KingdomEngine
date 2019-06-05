using KingdomEngine.Model;

namespace KingdomEngine.Interfaces
{
    public interface IEndTurnCalculator
    {
        int PeasantsGained { get; }
        int PeasantsLost { get; }
        int FoodProduced { get; }
        int FoodConsumed { get; }
        int TaxIncome { get; }
        void EndTurn(EndTurnPackage endTurnPackage);
    }
}
