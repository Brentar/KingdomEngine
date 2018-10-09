namespace KingdomEngine
{
    public interface IKingdomCalculator
    {
        int GetFarmCost(int turn);
        int GetFoodProduction(int farmCount);
        int GetFoodConsumed(int personCount);
        int GetTaxIncome(int peasantCount, int marketplaceCount);
    }
}
