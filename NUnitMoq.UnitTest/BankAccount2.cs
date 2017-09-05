using System;
using System.Collections.Generic;
using System.Text;

namespace NunitMoq.Lib
{
    public interface ILog
    {
        bool Write(string msg);
    }

    public class ConsoleLog : ILog
    {
        public bool Write(string msg)
        {
            Console.WriteLine(msg);
            return true;
        }
    }
    public class BankAccount2
    {
        public int Balance { get; set; }

        private readonly ILog log;

        public BankAccount2(ILog log)
        {
            this.log = log;
        }


        public void Deposit(int amount)
        {
            if (log.Write($"Depositing {amount}"))
            {
               Balance += amount;
            }
        }
    }
}
