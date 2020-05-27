using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Data
{
    public interface IMovementRepository
    {
        List<BankOperation> GetLastMovementsByAccount(Account account);
    }
}
