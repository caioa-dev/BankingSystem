using BankingSystem.Entities.Exceptions;
using System;
using System.Globalization;

namespace BankingSystem.Entities
{
    internal class Account : IGetOnCreditCard
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Balance { get; set; }
        public double CreditLimit { get; set; }
        internal double _debt = 0;
        public Account(string name, int iD, double balance, double creditLimit)
        {
            Name = name;
            ID = iD;
            Balance = balance;
            CreditLimit = creditLimit;
        }

        public Account(string name, int iD, double balance)
        {
            Name = name;
            ID = iD;
            Balance = balance;
        }

        public Account()
        {
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            try
            {
                if (Balance < amount)
                {
                    throw new CustomException("Not enough balance for this operation!");
                }
                else
                {
                    Balance -= amount;
                }
            }
            catch(CustomException c)
            {
                Console.WriteLine("An error occurred: " + c.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }
        }
        public virtual void GetOnCreditCard(double price)
        {
            try
            {
                if (price > CreditLimit)
                {
                    throw new CustomException("You can't buy this because your credit limit is too low for this purchase!");
                }
                else
                {
                    CreditLimit -= price;
                    _debt += price;
                }
            }
            catch (CustomException c)
            {
                Console.WriteLine("An error occurred: \n" + c.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An unpredicted error occurred: \n" + e.Message);
            }
        }
        public override string ToString()
        {
            return $"[{ID}] {Name}, ${Balance.ToString("F2", CultureInfo.InvariantCulture)}, " +
                $"credit limit: ${CreditLimit.ToString("F2", CultureInfo.InvariantCulture)}, " +
                $"debts (on credit card): ${_debt.ToString("F2", CultureInfo.InvariantCulture)}. ";
        }
    }
}
