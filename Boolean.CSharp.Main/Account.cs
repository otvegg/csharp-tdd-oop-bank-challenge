using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public enum Branches { Oslo, Tokyo, Sydney, Jakarta, New_York };
    public class Account
    {
        private Guid AccountId = Guid.NewGuid();
        private Branches Branch;
        private protected List<Transaction> transactions = new List<Transaction>();
        public Account(Branches branch) {
            Branch = branch;
        }

        public Guid GetAccountId() => AccountId;

        public List<Transaction> GetTransactions() => transactions;

        public decimal GetBalance()
        {
            return transactions.Sum(transaction => transaction.Deposit ? transaction.Amount : -transaction.Amount);
        }

        public void Deposit(decimal amount)
        {
            transactions.Add(new Transaction(true, amount));
        }


        public virtual bool Withdraw(decimal amount)
        {
            if (GetBalance() < amount) return false; 
            transactions.Add(new Transaction(false, amount));
            return true;
        }





        private string Center(string text, int width)
        {
            int padLeft = (width - text.Length) / 2 + text.Length;
            return text.PadLeft(padLeft).PadRight(width);
        }

        public string GetStatements() {
            
            StringBuilder sb = new StringBuilder();
            int DatePadding = 11;
            int MoneyPadding = 12;
            string decimalFormatting = "F";

            sb.AppendLine($"{Center("Date", DatePadding)}||{Center("Credit", MoneyPadding)}||{Center("Debit", MoneyPadding)}||{Center("Balance", MoneyPadding)}");

            decimal balance = 0;
            foreach (var transaction in transactions)
            {
                decimal value = transaction.Amount;
                balance = balance + (transaction.Deposit ? value : -value);
                string date = Center(transaction.timestamp, DatePadding);
                string credit = Center(transaction.Deposit ? value.ToString(decimalFormatting) : "", MoneyPadding);
                string debit = Center(transaction.Deposit ? "" : value.ToString(decimalFormatting), MoneyPadding);
                string bal = Center(balance.ToString(decimalFormatting), MoneyPadding);

                sb.AppendLine($"{date}||{credit}||{debit}||{bal}");
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }


    }
}
