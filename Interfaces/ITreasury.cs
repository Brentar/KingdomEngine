namespace KingdomEngine.Interfaces
{
    public interface ITreasury
    {
        int Gold { get; }
        void Deposit(int amount);
        void Withdraw(int amount);
    }
}
