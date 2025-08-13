using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
