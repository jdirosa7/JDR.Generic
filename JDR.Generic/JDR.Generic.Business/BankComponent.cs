using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDR.Generic.Data;
using JDR.Generic.Domain;

namespace JDR.Generic.Business
{
    public class BankComponent
    {
        public List<IAccount> GetAccounts()
        {
            BankDAC dac = new BankDAC();
            List<IAccount> result = default(List<IAccount>);

            result = dac.GetAllAccounts();
            return result;
        }
    }
}
