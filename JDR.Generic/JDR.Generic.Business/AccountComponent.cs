using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Business
{
    public abstract class AccountComponent
    {
        List<BankOperation> GetLastMovementsByAccount(Account account)
        {
            return null;
        }
    }
}
