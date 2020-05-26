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

        public void Deposit(BankOperation operation)
        {
            dac.Deposit(operation);
            //Crear movimiento
        }

        public void Extract(BankOperation operation)
        {
            IAccount source = operation.SourceAccount;
                        
            if(source.Balance >= operation.Value)
            {
                dac.Extract(operation);
                //Crear movimiento
            }
        }

        public void Transfer(BankOperation operation)
        {
            IAccount source = operation.SourceAccount;

            if (source.Balance >= operation.Value)
            {
                dac.Extract(operation);
                dac.Deposit(operation);                

                //Crear movimiento
            }            
        }
    }
}
