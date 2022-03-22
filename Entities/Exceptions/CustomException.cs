using System;

namespace BankingSystem.Entities.Exceptions
{
    internal class CustomException : ApplicationException
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
