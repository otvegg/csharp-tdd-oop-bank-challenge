using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private Guid id = Guid.NewGuid();
        public bool Deposit { get; }
        public decimal Amount { get; }
        public string timestamp = DateTime.Now.ToString("d");
        public Transaction(bool deposit, decimal amount)
        {
            Deposit = deposit;
            Amount = amount;
        }
    }
}
