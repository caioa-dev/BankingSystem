using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BankingSystem.Entities;
using BankingSystem.Entities.Store;

namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowTypesOfAccount();
            Account account = AskForInformation();

            Console.WriteLine(account);
            Console.WriteLine();

            Shop(account);

            Console.WriteLine();
            Console.WriteLine(account);

            Console.ReadLine();
        }
        static void ShowTypesOfAccount()
        {
            Console.WriteLine("Type: ");
            Console.WriteLine("1. for an usual account (Balance, $1,000 credit limit)");
            Console.WriteLine("2. a savings account (For savings only, no credit card)");
            Console.WriteLine("3. a business account (Balance, $10,000 on credit card. You can also add your workers)");
        }
        static Account AskForInformation()
        {
            Account acc = new Account();

            char? resp = null;

            try
            {
                resp = char.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }

            Console.Clear();

            switch (resp)
            {
                case '1':
                    NormalAccount normalAccount = new NormalAccount();
                    Console.WriteLine("What is your name? ");
                    normalAccount.Name = Console.ReadLine();
                    Console.WriteLine("Set the balance: ");
                    normalAccount.Balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    normalAccount.ID = 1; //solvable?

                    acc = normalAccount;

                    break;

                case '2':
                    SavingsAccount savingsAccount = new SavingsAccount();
                    Console.WriteLine("What is your name? ");
                    savingsAccount.Name = Console.ReadLine();
                    Console.WriteLine("Set the balance: ");
                    savingsAccount.Balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    savingsAccount.ID = 1; //gotta solve this

                    acc = savingsAccount;
                    break;

                case '3':
                    BusinessAccount businessAccount = new BusinessAccount();
                    Console.WriteLine("What is your name? ");
                    businessAccount.Name = Console.ReadLine();
                    Console.WriteLine("Set the balance: ");
                    businessAccount.Balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    businessAccount.ID = 1; //gotta solve this

                    Console.WriteLine("Do you want to add a new employee? (y/n)");
                    char response = char.Parse(Console.ReadLine());

                    while (response == 'y')
                    {
                        Console.Clear();

                        Console.WriteLine("Enter their name: ");
                        string wName = Console.ReadLine();
                        Console.WriteLine("Enter their working hours: ");
                        int wHour = int.Parse(Console.ReadLine());
                        Console.WriteLine("How much are you going to pay for the hour? ");
                        double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.WriteLine("Enter the id: ");
                        int id = int.Parse(Console.ReadLine());

                        businessAccount.AddNewWorker(wName, id, wHour, valuePerHour);

                        Console.WriteLine("Do you want to add another one? (y/n)");
                        response = char.Parse(Console.ReadLine());
                    }

                    Console.Clear();

                    Console.WriteLine("Do you want to remove an employee? (y/n) ");
                    char response2 = char.Parse(Console.ReadLine());
                    
                    while (response2 == 'y')
                    {
                        Console.Clear();

                        for (int i = 0; i < businessAccount.WorkersList.Count; i++)
                        {
                            Console.WriteLine($"Index: {i}, {businessAccount.WorkersList[i]}");
                        }
                        Console.WriteLine("Select the worker's index to get removed");
                        int index = int.Parse(Console.ReadLine());

                        businessAccount.FiredWorkers.Add(businessAccount.WorkersList[index]);
                        businessAccount.WorkersList.Remove(businessAccount.WorkersList[index]);

                        Console.WriteLine("Are you going to fire another one? (y/n)");
                        response2 = char.Parse(Console.ReadLine());
                    }

                    Console.Clear();

                    Console.WriteLine("Workers: ");
                    foreach (Worker w in businessAccount.WorkersList)
                    {
                        Console.WriteLine(w);
                    }

                    Console.WriteLine("Fired workers: ");
                    foreach (Worker w in businessAccount.FiredWorkers)
                    {
                        Console.WriteLine(w);
                    }

                    acc = businessAccount;

                    break;

                default:
                    AskForInformation();

                    break;
            }
            return acc;
        }
        static Account Shop(Account acc)
        {
            Console.WriteLine();

            char? response = null;

            Item Apple = new Item("Apple", .3, 57, Entities.Enums.ItemStatus.Available);
            Item Watermelon = new Item("Watermelon", 3.7, 7, Entities.Enums.ItemStatus.Available);
            Item Banana = new Item("Banana", .5, 47, Entities.Enums.ItemStatus.Available);

            List<Item> Items = new List<Item>();
            Items.Add(Apple); Items.Add(Watermelon); Items.Add(Banana);

            foreach (Item i in Items)
                Console.WriteLine(i);

            Console.WriteLine("\nDo you wanna get something? (y/n) ");
            try
            {
                response = char.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error occurred: \n" + e.Message);
            }
            while (response == 'y')
            {
                Console.WriteLine("Type 1 for apples, 2 for watermelons or 3 for bananas");
                int r = int.Parse(Console.ReadLine());
                switch (r)
                {
                    case 1:
                        Console.WriteLine("Enter the amount: ");
                        int a = int.Parse(Console.ReadLine());

                        Apple.Buy(a, acc);

                        break;

                    case 2:
                        Console.WriteLine("Enter the amount: ");
                        int b = int.Parse(Console.ReadLine());

                        Watermelon.Buy(b, acc);

                        break;

                    case 3:
                        Console.WriteLine("Enter the amount: ");
                        int c = int.Parse(Console.ReadLine());

                        Banana.Buy(c, acc);

                        break;

                    default:
                        Console.WriteLine("Error! going to the beggining of the funcion Shop!");
                        Shop(acc);

                        break;
                }

                Console.WriteLine("Do you wanna get something else? (y/n) ");
                response = char.Parse(Console.ReadLine());

                Console.Clear();

                foreach (Item i in Items)
                {
                    Console.WriteLine(i);
                }
            }
            return acc;
        }
    }
}
