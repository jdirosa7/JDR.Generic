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

        public void Deposit(BankOperation operation)
        {
            dac.Deposit(operation);
            //Crear movimiento
        }

        public void Extract(BankOperation operation)
        {
            IAccount source = operation.SourceAccount;

            dac.Extract(operation);
            //Crear movimiento
        }

        public void Transfer(BankOperation operation)
        {
            dac.Extract(operation);
            dac.Deposit(operation);            

            //Crear movimiento
        }
    }
}
