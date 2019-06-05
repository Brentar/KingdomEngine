using KingdomEngine.Interfaces;
using KingdomEngine.Model;

namespace KingdomEngine.Logic
{
    public class Kingdom : IKingdom
    {
        private readonly ITreasury treasury;
        private readonly IEndTurnCalculator endTurnCalculator;
        private readonly IEconomy economy;
        
        public Kingdom(ITreasury treasury, IEndTurnCalculator endTurnCalculator, IEconomy economy)
        {
            this.treasury = treasury;
            this.endTurnCalculator = endTurnCalculator;
            this.economy = economy;
        }

        public int PeasantCount { get; private set; }
        public int KnightCount { get; private set; }
        public int ArcherCount { get; private set; }
        public int FoodCount { get; private set; }
        public int MarketplaceCount { get; private set; }
        public int FarmCount { get; private set; }
        public double TaxRate { get; set; }   
        public int Gold => treasury.Gold;
        public int Turn { get; set; }

        public void BuyFarm()
        {
            treasury.Withdraw(economy.FarmCost);
            FarmCount++;
        }

        public void BuyMarketplace()
        {
            treasury.Withdraw(economy.MarketplaceCost);
            MarketplaceCount++;
        }

        public void TrainKnight()
        {
            treasury.Withdraw(economy.KnightCost);
            PeasantCount--;
            KnightCount++;
        }

        public void TrainArcher()
        {
            int archerCost = economy.ArcherCost;
            treasury.Withdraw(archerCost);
            ArcherCount++;
        }

        public int GetFarmCost()
        {
            return economy.FarmCost;
        }

        public int GetKnightCost()
        {
            return economy.KnightCost;
        }

        public int GetMarketplaceCost()
        {
            return economy.MarketplaceCost;
        }

        public void EndTurn()
        {
            var endTurnPackage = GetEndTurnPackage();
            endTurnCalculator.EndTurn(endTurnPackage);

            PeasantCount += endTurnCalculator.PeasantsGained;
            PeasantCount -= endTurnCalculator.PeasantsLost;
            FoodCount += endTurnCalculator.FoodProduced;
            treasury.Deposit(endTurnCalculator.TaxIncome);
            
            economy.InflateCosts();
            Turn++;
        }

        public TurnResults GetEndTurnResults()
        {
            var turnResults = new TurnResults
            {
                FoodConsumed = endTurnCalculator.FoodConsumed
            };

            return turnResults;
        }

        private EndTurnPackage GetEndTurnPackage()
        {
            return new EndTurnPackage
            {
                FarmCount = FarmCount,
                PeasantCount = PeasantCount,
                FoodCount = FoodCount,
                KnightCount = KnightCount
            };
        }
    }
}
