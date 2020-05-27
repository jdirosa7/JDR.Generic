using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.Generic.Data;
using JDR.Generic.Domain;

namespace JDR.Generic.Business
{
    public class CurrentAccountComponent : IAccountComponent
    {
        AccountDAC dac = new AccountDAC();
        BankComponent bankModule = new BankComponent();

        public void Deposit(BankOperation operation)
        {
            dac.Deposit(operation);
            bankModule.SaveMovement(operation);
        }

        public void Extract(BankOperation operation)
        {
            IAccount source = operation.SourceAccount;

            dac.Extract(operation);
            bankModule.SaveMovement(operation);
        }

        public void Transfer(BankOperation operation)
        {
            dac.Extract(operation);
            dac.Deposit(operation);

            bankModule.SaveMovement(operation);
        }
    }
}
