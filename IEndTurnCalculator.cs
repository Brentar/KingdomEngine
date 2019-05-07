using KingdomEngine.Model;

namespace KingdomEngine
{
    public interface IEndTurnCalculator
    {
        void EndTurn(EndTurnPackage endTurnPackage);
        int PeasantsGained { get; }
        int PeasantsLost { get; }
        int FoodProduced { get; }
    }
}
