using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.Generic.Data;
using JDR.Generic.Domain;

namespace JDR.Generic.Business
{
    public class BankComponent : IBankComponent
    {
        public List<Account> GetAccounts()
        {
            BankDAC dac = new BankDAC();
            List<Account> result = default(List<Account>);

            result = dac.GetAllAccounts();
            return result;
        }

        public void SaveMovement(BankOperation operation)
        {
            BankDAC dac = new BankDAC();
            MovementType movType = dac.GetMovementByName(operation.MovementType.Name);
            operation.MovementType = movType;
            dac.SaveMovement(operation);            
        }
    }
}
