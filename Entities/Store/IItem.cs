namespace BankingSystem.Entities.Store
{
    internal interface IItem
    {
        void Buy(int amount, Account acc);
    }
}
