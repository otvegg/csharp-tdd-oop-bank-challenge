using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        private bool? Status = null;
        public decimal Allowance = 0;

        public OverdraftRequest(decimal allowance) {
            Allowance = allowance;
            }

        public bool? GetStatus() => Status;
        public void Approve() => Status = true;
        public void Reject() => Status = false;

    }
}
