using BankingSystem.Entities.Exceptions;
using BankingSystem.Entities.Enums;
using System;

namespace BankingSystem.Entities.Store
{
    internal class Item : IItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int AmountAvailible { get; set; }
        public ItemStatus Status { get; set; }

        public Item(string name, double price, int amountAvailible, ItemStatus status)
        {
            Name = name;
            Price = price;
            AmountAvailible = amountAvailible;
            Status = status;
        }

        public void Buy(int amount, Account acc)
        {
            try
            {
                if (amount > AmountAvailible)
                {
                    throw new CustomException($"There are'nt enough {Name} for this purchase!");
                }
                else if (Price > acc.CreditLimit)
                {
                    throw new CustomException("Not enough credit limit!");
                }
                else if (amount > AmountAvailible && Price > acc.CreditLimit)
                {
                    throw new CustomException($"Your credit limit is low neither there are enough {Name.ToLower()}s!");
                }
                else
                {
                    if (AmountAvailible  == 0)
                    {
                        Status = ItemStatus.Unavailable;
                        throw new CustomException("This item is out of stock!");
                    }
                    else
                    {
                        AmountAvailible -= amount;
                        acc.GetOnCreditCard(amount * Price);
                    }
                }
            }
            catch (CustomException c)
            {
                Console.WriteLine("An error occurred: \n" + c.Message);
            }
        }

        public override string ToString()
        {
            return $"{Name} ({AmountAvailible}): {Price} status: {Status}";
        }
    }
}
