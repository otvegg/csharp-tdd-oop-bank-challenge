using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class CheckingAccount : Account
    {
        private OverdraftRequest? Overdraft = null;

        public CheckingAccount(Branches branch) : base(branch)
        {
        }

        public OverdraftRequest RequestOverdraft(decimal amount) {
            Overdraft = new OverdraftRequest(amount);
            return Overdraft;
        }

        public OverdraftRequest? GetOverdraft() { return Overdraft; }

        public bool Withdraw(decimal amount1)
        {
            if ((GetBalance() + (Overdraft?.GetStatus() == true ? Overdraft.Allowance : 0)) < amount1) return false;
            transactions.Add(new Transaction(false, amount1));
            return true;
        }

    }
}
