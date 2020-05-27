using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Business
{
    public interface IBankComponent
    {
        List<Account> GetAccounts();
        void SaveMovement(BankOperation operation);
    }
}
