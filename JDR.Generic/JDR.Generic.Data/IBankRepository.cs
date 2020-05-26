using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Data
{
    public interface IBankRepository
    {
        List<IAccount> GetAllAccounts();
    }
}
