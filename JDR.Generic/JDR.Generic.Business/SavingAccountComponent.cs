using JDR.Generic.Data;
using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Business
{
    public class SavingAccountComponent : IAccountComponent
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
                        
            if(source.Balance >= operation.Value)
            {
                dac.Extract(operation);
                bankModule.SaveMovement(operation);
            }
        }

        public void Transfer(BankOperation operation)
        {
            IAccount source = operation.SourceAccount;

            if (source.Balance >= operation.Value)
            {
                dac.Extract(operation);
                dac.Deposit(operation);

                bankModule.SaveMovement(operation);
            }            
        }
    }
}
