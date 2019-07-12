using System;
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
            Turn = 1;
        }

        public int PeasantCount { get; private set; }
        public int KnightCount { get; private set; }
        public int ArcherCount { get; private set; }
        public int FoodCount { get; private set; }
        public int MarketplaceCount { get; private set; }
        public int FarmCount { get; private set; }
        public double TaxRate { get; set; }   
        public int Turn { get; set; }
        public int Gold => treasury.Gold;
        public int FarmCost => economy.FarmCost;
        public int ArcherCost => economy.ArcherCost;
        public int MarketplaceCost => economy.MarketplaceCost;
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
            if (PeasantCount <= 0)
                throw new InvalidOperationException("No peasants to train.");

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
        
        public int GetKnightCost() => economy.KnightCost;

        public void EndTurn()
        {
            endTurnCalculator.EndTurn(GetEndTurnPackage());

            PeasantCount += endTurnCalculator.PeasantsGained;
            PeasantCount -= endTurnCalculator.PeasantsLost;
            FoodCount += endTurnCalculator.FoodProduced;
            FoodCount -= endTurnCalculator.FoodConsumed;

            treasury.Deposit(endTurnCalculator.TaxIncome);
            economy.InflateCosts();

            Turn++;
        }

        public TurnResults GetEndTurnResults()
        {
            var turnResults = new TurnResults
            {
                FoodConsumed = endTurnCalculator.FoodConsumed,
                FoodProduced = endTurnCalculator.FoodProduced,
                PeasantsGained = endTurnCalculator.PeasantsGained,
                PeasantsLost = endTurnCalculator.PeasantsLost,
                TaxIncome = endTurnCalculator.TaxIncome
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
