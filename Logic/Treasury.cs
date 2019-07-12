using System;
using KingdomEngine.Interfaces;
using KingdomEngine.Utility;

namespace KingdomEngine.Logic
{
    public class Treasury : ITreasury
    {
        public Treasury(int gold)
        {
            Gold = gold;
        }

        public int Gold { get; private set; }

        public void Deposit(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Gold += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (amount > Gold)
                throw new NotEnoughGoldException("Not enough gold.");

            Gold -= amount;
        }
    }
}
