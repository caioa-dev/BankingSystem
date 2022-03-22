using BankingSystem.Entities.Enums;

namespace BankingSystem.Entities
{
    internal sealed class Worker
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Hours { get; set; }
        public double ValuePerHour { get; set; }
        public WorkerStatus workerStatus { get; set; }
        public Worker(string name, int iD, int hours, double valuePerHour)
        {
            Name = name;
            ID = iD;
            Hours = hours;
            ValuePerHour = valuePerHour;
        }
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
        public override string ToString()
        {
            return $"[{ID}] {Name}: ${TotalValue()}. ";
        }
    }   
}
