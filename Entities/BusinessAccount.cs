using System.Globalization;
using System.Collections.Generic;
using System.IO;
using BankingSystem.Entities.Enums;

namespace BankingSystem.Entities
{
    internal sealed class BusinessAccount : Account
    {
        public List<Worker> WorkersList { get; set; } = new List<Worker>();
        public List<Worker> FiredWorkers { get; set; } = new List<Worker>();
        private double _creditLimit = 10000;
        public BusinessAccount()
        {
            this.CreditLimit = _creditLimit;
        }
        public BusinessAccount(string name, int iD, double balance)
            : base(name, iD, balance)
        {
            Name = name;
            ID = iD;
            Balance = balance;
            this.CreditLimit = _creditLimit;
        }
        public void AddNewWorker(string wName, int wId, int wHours, double wValuePerHour)
        {
            Worker worker = new Worker(wName, wId, wHours, wValuePerHour);
            worker.workerStatus = WorkerStatus.Hired;
            WorkersList.Add(worker);
        }
        public void RemoveWorker(Worker worker)
        {
            worker.workerStatus = WorkerStatus.Fired;
            FiredWorkers.Add(worker);
            WorkersList.Remove(worker);
        }
        public override string ToString()
        {
            return base.ToString() + $"You have {WorkersList.Count} hired workers, " +
                $"{FiredWorkers.Count} fired workers, sum = {WorkersList.Count + FiredWorkers.Count} workers.";
        }
    }
}
