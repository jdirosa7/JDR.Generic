using JDR.Generic.Domain;
using JDR.Generic.Services.Contracts.Request;
using JDR.Generic.Services.Contracts.Response;
using JDR.Generic.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.UI.Process
{
    public class BankProcess : ProcessComponent
    {
        public List<Account> GetAccounts()
        {
            var response = HttpGet<BankResponse>("api/bank/getAccounts", new Dictionary<string, object>(), MediaType.Json);
            return response.Accounts;
        }
    }
}
