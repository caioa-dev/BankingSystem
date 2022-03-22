namespace BankingSystem.Entities
{
    internal sealed class NormalAccount : Account
    {
        private double _creditLimit = 1000;
        public NormalAccount()
        {
            this.CreditLimit = _creditLimit;
        }
        public NormalAccount(string name, int iD, double balance) 
            : base(name, iD, balance)
        {
            Name = name;
            Balance = balance;
            this.CreditLimit = _creditLimit;
        }
    }
}
