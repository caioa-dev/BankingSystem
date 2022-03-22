using BankingSystem.Entities.Exceptions;
using System;

namespace BankingSystem.Entities
{
    internal sealed class SavingsAccount : Account
    {
        private double _percentageIncomePerMonth = 1.025; //2.5% per month
        //savings accounts don't have credit cards
        public SavingsAccount(string name, int iD, double balance) : base (name, iD, balance)
        {
            Name = name;
            ID = iD;
            Balance = balance;
        }
        public SavingsAccount()
        {
        }
        public void GoToTheFuture(int months)
        {
            for (int i = 0; i < months - 1; i++)
            {
                _percentageIncomePerMonth *= _percentageIncomePerMonth;
            }
            Balance *= _percentageIncomePerMonth;
        }
        public override void GetOnCreditCard(double amount)
        {
            try
            {
                if (amount >= Balance)
                {
                    throw new CustomException("You don't have a credit card!");
                }
            }
            catch(CustomException c)
            {
                Console.WriteLine("An error occurred: \n" + c.Message);
            }
        }
        public override string ToString()
        {
            return $"[{ID}] {Name}, balance: ${Balance}";
        }
    }
}
