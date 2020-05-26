using JDR.Generic.Business;
using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Services
{
    public class AccountService
    {
        SavingAccountComponent bs = new SavingAccountComponent();


        public void Deposit(BankOperation operation)
        {
            bs.Deposit(operation);
        }

        public void Extract(BankOperation operation)
        {
            bs.Extract(operation);
        }

        public void Transfer(BankOperation operation)
        {
            bs.Transfer(operation);
        }
    }
}
