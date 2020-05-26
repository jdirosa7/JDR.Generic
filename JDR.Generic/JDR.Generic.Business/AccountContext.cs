using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Business
{
    public class AccountContext
    {
        IAccountComponent bankOperation;

        public AccountContext(IAccountComponent operation)
        {
            this.bankOperation = operation;
        }

        public void Deposit(BankOperation operation)
        {
            this.bankOperation.Deposit(operation);
        }

        public void Extract(BankOperation operation)
        {
            this.bankOperation.Extract(operation);
        }

        public void Transfer(BankOperation operation)
        {
            this.bankOperation.Transfer(operation);
        }
    }
}
